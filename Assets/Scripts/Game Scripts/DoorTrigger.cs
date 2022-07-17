using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    string _sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("SceneManager"))
        {
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SwitchScene>().ChangeScene(_sceneName);
        } else
        {
            Debug.LogWarning("Could not find Scene Manager!");
        }
    }
}
