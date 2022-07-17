using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    Rigidbody2D rb;

    public void PlayLFootstep()
    {
        FindObjectOfType<SoundManager>().PlaySound("LeftFootstep");
    }

    public void PlayRFootstep()
    {
        FindObjectOfType<SoundManager>().PlaySound("RightFootstep");
    }

    private void Update()
    {
        
    }

    public void PlayPlayerDeath()
    {
        Debug.Log("Player Death. End Game.");
        GetComponent<PlayerMovement>().isAlive = false;
    }
}
