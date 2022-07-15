using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpVelocity = 1f;

    bool _onGround = true;

    // Update is called once per frame
    void Update()
    {
        //player movement
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime);

        //player jump
        if (Input.GetButtonDown("Jump") && _onGround)
        {

            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;

        }
    }

    private void FixedUpdate()
    {

        Vector3 _modifiedCastPosition = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
        RaycastHit2D hit = Physics2D.Raycast(_modifiedCastPosition, Vector2.down, 1f);
        if (hit.collider != null && hit.collider.tag == "Floor")
        {
            _onGround = true;
            return;
        }
        else
        {
            _onGround = false;
            return;
        }


    }
}
