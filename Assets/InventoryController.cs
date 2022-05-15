using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryController : MonoBehaviour
{
    public GameObject[] allInventoryItems;

    public void UpdateInventory(GameObject newInventoryItem)
    {
        if (!Array.Exists(allInventoryItems, i => i == newInventoryItem))
        {
            Debug.LogError("No inventory item for: " + newInventoryItem.name);
            return;
        }
        else
        {
            for (int i = 0; i < allInventoryItems.Length; i++)
            {
                if (allInventoryItems[i] == newInventoryItem)
                    allInventoryItems[i].SetActive(true);
            }
        }
    }
}
