using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (GameObject.FindGameObjectWithTag("SceneManager"))
        {
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SwitchScene>().ChangeScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.LogWarning("Could not find Scene Manager!");
        }
    }

    IEnumerator DeathGo()
    {
        yield return new WaitForSeconds(.1f);

        if (GameObject.FindGameObjectWithTag("SceneManager"))
        {
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SwitchScene>().ChangeScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.LogWarning("Could not find Scene Manager!");
        }
    }
}
