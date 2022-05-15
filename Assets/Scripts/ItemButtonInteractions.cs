using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButtonInteractions : MonoBehaviour
{
    public string interactText;
    public GameObject interactScene;
    public GameObject inventoryItem;

    public void Start()
    {
        if (interactText == "")
        {
            interactText = this.name + " HAS NO INTERACT TEXT";
        }
    }

    public void InteractText()
    {
        MenuManager.Instance.UpdateInfoText(interactText);
        if (inventoryItem != null)
            MenuManager.Instance.UpdateInventory(inventoryItem);
    }

    public void InteractScene()
    {
        MenuManager.Instance.UpdateInfoText(interactText);
        MenuManager.Instance.UpdateBackground(interactScene);
        if (inventoryItem != null)
            MenuManager.Instance.UpdateInventory(inventoryItem);
    }
}
