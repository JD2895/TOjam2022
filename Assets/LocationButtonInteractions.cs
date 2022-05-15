using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationButtonInteractions: MonoBehaviour
{
    public string interactText;
    public GameObject interactScene;

    public void Interact()
    {
        MenuManager.Instance.UpdateInfoText(interactText);
        MenuManager.Instance.UpdateBackground(interactScene);
    }
}
