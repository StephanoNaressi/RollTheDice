using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    PlayerMovement _playerMovement;

    [SerializeField]
    DieSlot _jumpSlot, _speedSlot;

    private void Update()
    {
        CheckSlots();
    }

    //update player ability values based on input boxes
    void CheckSlots()
    {
        if (_playerMovement.jumpVelocity == _jumpSlot.slotDieValue) { _jumpSlot.newValueAdded = false; }
        if (_jumpSlot.newValueAdded) { _playerMovement.jumpVelocity = _jumpSlot.slotDieValue; }

        if (_playerMovement.speed == _speedSlot.slotDieValue) { _speedSlot.newValueAdded = false; }
        if (_speedSlot.newValueAdded) { _playerMovement.speed = _speedSlot.slotDieValue; }
    }
}
