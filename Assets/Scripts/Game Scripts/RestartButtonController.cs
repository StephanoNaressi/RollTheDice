using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonController : MonoBehaviour
{

    public void OnPress()
    {
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
