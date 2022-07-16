using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 0;
    public int jumpVelocity = 0;
    public int attackStrength = 0;
    public bool inCombat = false;
    public Enemy enemy;

    bool _onGround = true;
    
    

    // Update is called once per frame
    void Update()
    {
        //stop player movement input during combat sequence
        if (!inCombat)
        {
            //player movement
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime);

            //player jump
            if (Input.GetButtonDown("Jump") && _onGround)
            {

                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;

            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(enemy.targetStanceLocation, transform.position.y), 1f * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        //Tests player is on ground to prevent flight
        //_modifiedCastPosition moves the cast up to prevent the cast from passing through collieder below
        Vector3 _modifiedCastPosition = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
        RaycastHit2D hit = Physics2D.Raycast(_modifiedCastPosition, Vector2.down, .5f);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            inCombat = true;
            enemy = collision.gameObject.GetComponent<EnemyInfo>().enemy;
        }
    }
}
