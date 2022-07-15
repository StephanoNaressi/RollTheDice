using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    [SerializeField]
    [Range(0,10)]
    float fallMultiplier;
    [SerializeField]
    [Range(0, 10)]
    float lowJumpMultiplier;

    [SerializeField]
    Rigidbody2D rb;

    private void Update()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
