using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoController : MonoBehaviour
{
    public TextMeshProUGUI infoText;

    public void UpdateInfo(string newText)
    {
        newText = newText.Replace("\\n", "\n");
        infoText.text = newText;
        AudioManager.Instance.PageFlip();
    }
}
