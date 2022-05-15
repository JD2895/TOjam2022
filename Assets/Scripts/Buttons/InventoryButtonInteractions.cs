using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryButtonInteractions : MonoBehaviour
{
    public TextMeshProUGUI itemText;

    public void UpdateText()
    {
        itemText.text = this.gameObject.name;
        //Debug.Log(this.name + " is getting updated to " + itemText.text);
    }

    public void Interact()
    {
        if (itemText.text == "???")
        {
            MenuManager.Instance.ShowClueNotFoundTip();
            return;
        }

        if (!MenuManager.Instance.inCharacterMode)
        {
            MenuManager.Instance.ShowChoosePersonTip();
            MenuManager.Instance.FindItemUpdateInfoText(this.name);
            return;
        }

        MenuManager.Instance.PersonItemInteraction(this.gameObject);
    }
}
