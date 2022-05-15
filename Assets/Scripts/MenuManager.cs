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
    }

    public void PersonItemInteraction(GameObject checkItem)
    {
        allPeopleController.PersonItemInteraction(checkItem);
    }
}
