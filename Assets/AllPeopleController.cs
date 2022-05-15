using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPeopleController : MonoBehaviour
{
    private List<GameObject> allPeople = new List<GameObject>();

    public void FillPeople()
    {
        foreach (Transform child in this.transform)
        {
            Debug.Log(child.name);
            if (child.gameObject.activeSelf)
            {
                allPeople.Add(child.gameObject);
            }
        }
    }

    public void TogglePeople(GameObject personToToggle)
    {
        if (!allPeople.Contains(personToToggle))
        {
            Debug.LogError("No peron found for: " + personToToggle.name);
            return;
        }
        else
        {
            for (int i = 0; i < allPeople.Count; i++)
            {
                if (allPeople[i].name == personToToggle.name)
                {
                    allPeople[i].SetActive(!allPeople[i].activeSelf);
                    MenuManager.Instance.inCharacterMode = allPeople[i].activeSelf;
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
    }
}
