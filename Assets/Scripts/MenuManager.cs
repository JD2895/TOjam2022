using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuManager : MonoBehaviour
{
    private int currentDosierTab = 0;
    public bool inCharacterMode = false;
    public GameObject currentPersonObject;

    public DossierController dossierController;
    public InfoController infoController;
    public BackgroundController backgroundController;
    public InventoryController inventoryController;
    public AllPeopleController allPeopleController;
    public GameObject kitchenInteractablesContainer;
    public GameObject fridgeInteractablesContainer;
    public GameObject endObject;

    public GameObject choosePersonTip;
    private int choosePersonTipCounter = 0;
    public GameObject clueNotFoundTip;

    public GameObject[] introObjects;
    public bool skipIntro = false;

    private static MenuManager _instance;

    public static MenuManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        inventoryController.FillInventory();
        allPeopleController.FillPeople();
        
        if (!skipIntro)
            ShowIntroWindows();
    }

    public void ShowIntroWindows()
    {
        AudioManager.Instance.PageFlip();
        foreach (GameObject obj in introObjects)
        {
            obj.SetActive(true);
        }
    }

    public void ChangeDossierTab(int tabChoice)
    {
        if (currentDosierTab == tabChoice)
            return;

        AudioManager.Instance.PageFlip();
        dossierController.ChangeDossierTab(tabChoice);
        currentDosierTab = tabChoice;
    }

    public void UpdateInfoText(string newText)
    {
        infoController.UpdateInfo(newText);
    }

    public void FindItemUpdateInfoText(string itemToFind)
    {
        foreach (Transform child in kitchenInteractablesContainer.transform)
        {
            if (child.name == itemToFind)
            {
                child.GetComponent<ItemButtonInteractions>().InteractText();
                return;
            }
        }

        foreach (Transform child in fridgeInteractablesContainer.transform)
        {
            if (child.name == itemToFind)
            {
                child.GetComponent<ItemButtonInteractions>().InteractText();
                return;
            }
        }

        Debug.Log("not found");
    }

    public void UpdateBackground(GameObject newBackground)
    {
        if (inCharacterMode)
            allPeopleController.DisableAllPeople();
        backgroundController.ChangeBackground(newBackground);
    }

    public void UpdateInventory(GameObject newInventoryItem)
    {
        inventoryController.UpdateInventory(newInventoryItem);
    }

    public void TogglePerson(GameObject newPerson)
    {
        currentPersonObject = newPerson;
        allPeopleController.TogglePeople(newPerson);
        if (inCharacterMode)
            ChangeDossierTab(1);
    }

    public void PersonItemInteraction(GameObject checkItem)
    {
        allPeopleController.PersonItemInteraction(checkItem);
    }

    public void ShowChoosePersonTip()
    {
        if (choosePersonTipCounter < 1)
        {
            choosePersonTipCounter += 1;
            //ChangeDossierTab(0);
            choosePersonTip.SetActive(true);
        }
    }

    public void ShowClueNotFoundTip()
    {
        AudioManager.Instance.PageFlip();
        ChangeDossierTab(0);
        clueNotFoundTip.SetActive(true);
    }

    public void ShowEnd()
    {
        AudioManager.Instance.PageFlip();
        endObject.SetActive(true);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
