using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPeopleController : MonoBehaviour
{
    private List<GameObject> allPeople = new List<GameObject>();
    private PersonController currentPersonController;

    public void FillPeople()
    {
        foreach (Transform child in this.transform)
        {
            allPeople.Add(child.gameObject);
        }
    }

    public void TogglePeople(GameObject personToToggle)
    {
        if (!allPeople.Contains(personToToggle))
        {
            Debug.LogError("No person found for: " + personToToggle.name);
            return;
        }
        else
        {
            for (int i = 0; i < allPeople.Count; i++)
            {
                if (allPeople[i].name == personToToggle.name)
                {
                    allPeople[i].SetActive(!allPeople[i].activeSelf);
                    //MenuManager.Instance.inCharacterMode = allPeople[i].activeSelf;
                    if (allPeople[i].activeSelf)
                    {
                        MenuManager.Instance.inCharacterMode = true;
                        currentPersonController = allPeople[i].GetComponent<PersonController>();
                    }
                    else
                    {
                        MenuManager.Instance.inCharacterMode = false;
                        currentPersonController = null;
                    }
                }
                else
                    allPeople[i].SetActive(false);
            }
        }
    }

    public void DisableAllPeople()
    {
        for (int i = 0; i < allPeople.Count; i++)
        {
            allPeople[i].SetActive(false);
        }
        MenuManager.Instance.inCharacterMode = false;
    }

    public void PersonItemInteraction(GameObject checkItem)
    {
        if (currentPersonController == null)
        {
            Debug.LogError("Can't interact with person, is null");
            return;
        }

        string response = currentPersonController.GetResponse(checkItem);

        if (response == null)
        {
            Debug.LogError(currentPersonController.transform.name + "doesn't have a response for " + checkItem.name);
            return;
        }

        MenuManager.Instance.UpdateInfoText(response);
    }
}
