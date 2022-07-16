using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[Serializable]
public class Die
{
    public string name;
    public int maxRoll;
    public List<Sprite> possibleFaces = new List<Sprite>();

    public int value;
    public bool rolled = false;
    public bool used = false;
    public Image image;
}


public class Dice : MonoBehaviour, IPointerClickHandler
{
    public Die die;

    public void RollDie()
    {
        if (!die.rolled)
        {
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
