using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryController : MonoBehaviour
{
    public List<GameObject> allInventoryItems;
    public GameObject inventoryItemContainer;

    public void FillInventory()
    {
        foreach (Transform child in inventoryItemContainer.transform)
        {
            if (child.gameObject.activeSelf)
            {
                allInventoryItems.Add(child.gameObject);
            }
        }
    }

    public void UpdateInventory(GameObject newInventoryItem)
    {
        if (!allInventoryItems.Contains(newInventoryItem))
        {
            Debug.LogError("No inventory item for: " + newInventoryItem.name);
            return;
        }
        else
        {
            for (int i = 0; i < allInventoryItems.Count; i++)
            {
                if (allInventoryItems[i] == newInventoryItem)
                {
                    newInventoryItem.GetComponent<InventoryItemController>().UpdateText();
                }
                    //allInventoryItems[i].SetActive(true);
            }
        }
    }
}
