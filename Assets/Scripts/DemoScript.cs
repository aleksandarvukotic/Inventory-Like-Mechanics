using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows me to check some functionality of the inventory.
public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;

    // Checking inventory status, full or not
    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if(result == true)
        {
            Debug.Log("Item added");
        }
        else
        {
            Debug.Log("Inventory full");
        }
    }

    // Method to check/inspect received && selected item in inventory, should give explanation through UI ingame.
    public void GetSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(false);
        if (receivedItem != null)
        {
            Debug.Log("Received item" + receivedItem);
        } else
        {
            Debug.Log("No item received");
        }
    }

    // Method to use selected item, it will provide some kind of action depending on item activated.
    public void UseSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(true);
        if (receivedItem != null)
        {
            Debug.Log("Used item" + receivedItem);
        }
        else
        {
            Debug.Log("No item used");
        }
    }
}