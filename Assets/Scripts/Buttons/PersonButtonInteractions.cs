using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonButtonInteractions : MonoBehaviour
{
    public string interactText;
    public string personLeavingText;
    public GameObject personObject;

    public void Start()
    {
        if (interactText == "")
        {
            interactText = this.name + " HAS NO INTERACT TEXT";
        }
        if (personLeavingText == "")
        {
            personLeavingText = this.name + " HAS NO LEAVING TEXT";
        }
    }

    public void Interact()
    {
        if (!MenuManager.Instance.inCharacterMode)
        {
            MenuManager.Instance.UpdateInfoText(interactText);
        }
        else
        {
            if (MenuManager.Instance.currentPersonObject == personObject)
                MenuManager.Instance.UpdateInfoText(personLeavingText);
            else
                MenuManager.Instance.UpdateInfoText(interactText);
        }
        MenuManager.Instance.TogglePerson(personObject);
    }
}
