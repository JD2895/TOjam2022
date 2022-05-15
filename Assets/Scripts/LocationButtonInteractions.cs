using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationButtonInteractions: MonoBehaviour
{
    public string interactText;
    public GameObject interactScene;

    public void Start()
    {
        if (interactText == "")
        {
            interactText = this.name + " HAS NO INTERACT TEXT";
        }
    }

    public void Interact()
    {
        MenuManager.Instance.UpdateInfoText(interactText);
        MenuManager.Instance.UpdateBackground(interactScene);
    }
}
