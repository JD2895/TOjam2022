using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryItemController : MonoBehaviour
{
    public TextMeshProUGUI itemText;

    public void UpdateText()
    {
        itemText.text = this.gameObject.name;
    }
}
