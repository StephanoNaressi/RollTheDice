using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Class to hold all information about our dice
[Serializable]
public class Die
{
    public string name;
    public int maxRoll;
    public List<Sprite> possibleFaces = new List<Sprite>();

    [HideInInspector]
    public int value;
    [HideInInspector]
    public bool rolled = false;
    [HideInInspector]
    public bool used = false;

    public Image image;
}


public class Dice : MonoBehaviour, IPointerClickHandler
{
    public Die die;

    bool _playOnce;

    private void Start()
    {
        if (FindObjectOfType<SoundManager>()._isDone)
        {
            FindObjectOfType<SoundManager>().PlaySound("RollingDice");
            _playOnce = false;
        }
    }

    private void Update()
    {
        if (_playOnce)
        {
            if (FindObjectOfType<SoundManager>())
            {
                FindObjectOfType<SoundManager>().PlaySound("RollingDice");
                _playOnce = false;
            }
        }
    }
    //Rolls and sets our dices value
    public void RollDie()
    {
        if (!die.rolled)
        {
            FindObjectOfType<SoundManager>().PlaySound("DiceEndRoll");
            GetComponent<Animator>().enabled = false;


            int rolledDie = UnityEngine.Random.Range(1, die.maxRoll);
            die.value = rolledDie;
            die.rolled = true;

            die.image.sprite = die.possibleFaces[rolledDie - 1];
        }

    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        RollDie();
    }
}
