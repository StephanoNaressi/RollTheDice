using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDiceRoll : MonoBehaviour
{
    bool done = false;
    GameObject[] dice;
    List<Die> die = new List<Die>();

    private void Start()
    {
        dice = GameObject.FindGameObjectsWithTag("Die");

        foreach(GameObject d in dice)
        {
            die.Add(d.GetComponent<Dice>().die);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            foreach(Die d in die)
            {
                if (!d.rolled)
                {
                    return;
                }
            }
            FindObjectOfType<SoundManager>().StopSound("RollingDice");
            done = true;
        }
    }
}
