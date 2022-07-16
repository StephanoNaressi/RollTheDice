using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DieSlot : MonoBehaviour, IDropHandler
{
    public int slotDieValue = -1;
    public bool newValueAdded = false;

    //When a die is dropped into the box it is read allowing the box to hold the dices' value
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<Dice>().die.rolled && !eventData.pointerDrag.GetComponent<Dice>().die.used)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<Dice>().die.used = true;
                slotDieValue = eventData.pointerDrag.GetComponent<Dice>().die.value;
                newValueAdded = true;
            }
            else
            {
                Debug.Log("Roll Die First");
            }
            
        }
    }
}
