using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, notSelectedColor;

    private void Awake()
    {
        Deselect();
    }

    // Changing color of selected inventory slot.
    public void Select()
    {
        image.color = selectedColor;
    }

    // Setting color of unselected slot back to default.
    public void Deselect()
    {
        image.color = notSelectedColor;
    }

    // Ability of invenotry slot to accept item if its empty && you end drag over them.
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0) 
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
        }
    }
}
