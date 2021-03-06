using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Verify player was found
        if (player == null)
        {
            Debug.Log("Player not found. Will Check again");
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            if (player.GetComponent<PlayerMovement>().isAlive)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, -10);
            }
            
        }
    }
}
