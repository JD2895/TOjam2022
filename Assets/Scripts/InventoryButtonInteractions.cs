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
    }

    public void Interact()
    {
        if (!MenuManager.Instance.inCharacterMode)
        {
            //TELl THE PLAYER TO GO INTO CHARACTER MODE
            Debug.Log("GO TO CHARACTER PLS");
            return;
        }

        if (itemText.text == "???")
        {
            Debug.Log(this.name + " CLUE NOT FOUND! - " + itemText.text);
            return;
        }

        MenuManager.Instance.PersonItemInteraction(this.gameObject);
    }
}
