using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
    PlayerMovement _playerMovement;

    [SerializeField]
    DieSlot _jumpSlot, _speedSlot, _attackSlot;

    // Start is called before the first frame update
    void Start()
    {
        //Verify player was found
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerMovement = player.GetComponent<PlayerMovement>();
        }
    }

    private void Update()
    {
        //Verify player was found
        if (player == null)
        {
            Debug.Log("Player not found. Will Check again");
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                _playerMovement = player.GetComponent<PlayerMovement>();
            }
            return;
        }

        CheckSlots();
        
        if (_playerMovement.inCombat)
        {
            Combat();
        }
    }

    void Combat()
    {
        //Checks combat ability vs enemy runs appropriate response
        if (_playerMovement.attackStrength == 0)
        {
            Debug.Log("Add Die!");
        }
        else if (_playerMovement.attackStrength >= _playerMovement.enemy.health)
        {
            _playerMovement.enemy.isDead = true;
            _playerMovement.enemy = null;
            _playerMovement.inCombat = false;
        } else
        {
            Debug.Log("Player Death. End Game.");
            player.GetComponent<PlayerAnimationController>().PlayPlayerDeath();
        }
    }

    //update player ability values based on input boxes
    void CheckSlots()
    {
        if (_playerMovement.jumpVelocity == _jumpSlot.slotDieValue) { _jumpSlot.newValueAdded = false; }
        if (_jumpSlot.newValueAdded) { _playerMovement.jumpVelocity = _jumpSlot.slotDieValue; }

        if (_playerMovement.speed == _speedSlot.slotDieValue) { _speedSlot.newValueAdded = false; }
        if (_speedSlot.newValueAdded) { _playerMovement.speed = _speedSlot.slotDieValue; }

        if (_playerMovement.attackStrength == _attackSlot.slotDieValue) { _attackSlot.newValueAdded = false; }
        if (_attackSlot.newValueAdded) { _playerMovement.attackStrength = _attackSlot.slotDieValue; }
    }
}
