using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    Canvas canvas;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    [SerializeField] Dice dice;
    Vector2 originalAnchorPoint;


    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        originalAnchorPoint = rectTransform.anchoredPosition;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    //When Drag is ended verify dice was dropped into a box if not return it to original location
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!dice.die.used)
        {
            rectTransform.anchoredPosition = originalAnchorPoint;
        }
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    //When dragged keep UI element on cursor
    public void OnDrag(PointerEventData eventData)
    {
        if (dice.die.rolled && !dice.die.used)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        } else
        {
            Debug.Log("Roll Die First");
        }
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (dice.die.rolled && !dice.die.used)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
            FindObjectOfType<SoundManager>().PlaySound("DiceDragDrop");
        }
        else
        {
            Debug.Log("Roll Die First");
        }
        
    }
}
