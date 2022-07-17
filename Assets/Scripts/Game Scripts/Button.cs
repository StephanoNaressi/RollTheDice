using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    [SerializeField]
    string _SceneName;

    public void OnPress()
    {
        if (GameObject.FindGameObjectWithTag("SceneManager"))
        {
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SwitchScene>().ChangeScene(_SceneName);
        }
        else
        {
            Debug.LogWarning("Could not find Scene Manager!");
        }
    }
}
