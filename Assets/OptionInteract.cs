using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionInteract : MonoBehaviour
{
    public TextMeshProUGUI fillingInOption;

    public void FillIn()
    {
        fillingInOption.text = this.GetComponentInChildren<TextMeshProUGUI>().text;
    }
}
