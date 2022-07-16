using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//Class creates enemy for level design
[Serializable]
public class Enemy
{
    public int health;
    public float targetStanceLocation;
    public bool isRight;
    public bool isDead;
    
}

public class EnemyInfo : MonoBehaviour
{
    public Enemy enemy;

    [SerializeField]
    Image healthIndicator;

    [SerializeField]
    List<Sprite> healthDice = new List<Sprite>();

    private void Start()
    {
        //presets combat distance for animation
        if (enemy.isRight)
        {
            enemy.targetStanceLocation = transform.position.x + 2.75f;
        } else
        {
            enemy.targetStanceLocation = transform.position.x - 2.75f;
        }
        //indicates health to player
        healthIndicator.sprite = healthDice[enemy.health - 1];
    }

    private void Update()
    {
        if (enemy.isDead)
        {
            Destroy(this.gameObject);
        }
    }
}
