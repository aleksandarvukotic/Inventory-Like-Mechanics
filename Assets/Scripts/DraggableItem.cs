using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector] public Item item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    // Initialisation of item in invenotry.
    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }

    // UI element providing text over item sprite, showing us how many items we have on stack if item is stackable.
    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }


    // My first usage of interfaces. Here we use them for dragging of selected item.
    // Item raycastTarget is set to false so coursor can detect new slot underneat it and move item to it, otherwise item always returns to the slot it belong to.
    // Also we set item as Last Sibling so it shows as on top of any UI elemnet in Unity inspector.
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    // Changing position of item with mouse movement.
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;

    }

    // 
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag ended");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
