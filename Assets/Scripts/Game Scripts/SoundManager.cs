using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public Sound[] sounds;

    public bool _isDone = false;

    bool _LastSceneMenu;
    bool _isMenu;
    

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        _isDone = true;
    }

    private void Start()
    {
        PlaySound("GameTheme");
        PlaySound("Ambience");
    }

    private void Update()
    {

        /*if (_isMenu)
        {
            _LastSceneMenu = true;
        } else
        {
            _LastSceneMenu = false;
        }

        if (SceneManager.GetActiveScene().name == "StartingScene" || SceneManager.GetActiveScene().name == "Level Select")
        {
            _isMenu = true;
        } else
        {
            _isMenu = false;
        }



        if (GameObject.FindGameObjectWithTag("GameManager") && _LastSceneMenu)
        {
            PlaySound("GameTheme");
            PlaySound("Ambience");
        } else if (!GameObject.FindGameObjectWithTag("GameManager"))
        {
            PlaySound("GameThemeMenu");
        }*/
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }

}
