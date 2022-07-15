using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieRoller : MonoBehaviour
{
    [SerializeField]
    List<GameObject> diePrefabs = new List<GameObject>();

    [SerializeField]
    int _dieAmount;

    Vector3 spawnLocation;

    private void Start()
    {
        spawnLocation = new Vector3(transform.position.x, transform.position.y - 13f, transform.position.z);

        int spawnedDice = 0;
        while(spawnedDice < _dieAmount)
        {
            Instantiate(diePrefabs[0],spawnLocation,Quaternion.identity);
            spawnedDice++;
        }
    }

}
