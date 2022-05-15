using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuManager : MonoBehaviour
{
    private int currentDosierTab = 0;
    public bool inCharacterMode = false;

    public DossierController dossierController;
    public InfoController infoController;
    public BackgroundController backgroundController;
    public InventoryController inventoryController;
    public AllPeopleController allPeopleController;
    public GameObject interactablesContainer;

    public GameObject choosePersonTip;
    private int choosePersonTipCounter = 0;
    public GameObject clueNotFoundTip;

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
    }


    public void ChangeDossierTab(int tabChoice)
    {
        if (currentDosierTab == tabChoice)
            return;

        dossierController.ChangeDossierTab(tabChoice);
        currentDosierTab = tabChoice;
    }

    public void UpdateInfoText(string newText)
    {
        infoController.UpdateInfo(newText);
    }

    public void FindItemUpdateInfoText(string itemToFind)
    {
        foreach (Transform child in interactablesContainer.transform)
        {
            if (child.name == itemToFind)
            {
                child.GetComponent<ItemButtonInteractions>().InteractText();
                return;
            }
        }
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

    public void TogglePerson(GameObject newPeron)
    {
        allPeopleController.TogglePeople(newPeron);
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
        ChangeDossierTab(0);
        clueNotFoundTip.SetActive(true);
    }
}
