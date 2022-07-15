using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Die
{
    public string name;
    public int maxRoll;
    public List<Sprite> possibleFaces = new List<Sprite>();
}


public class Dice : MonoBehaviour
{
    public Die die;

    public int RollDie(Die passedDie)
    {
        int rolledDie = UnityEngine.Random.Range(1, passedDie.maxRoll);
        return rolledDie;
    }
}
