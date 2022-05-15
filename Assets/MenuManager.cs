using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private int currentDosierTab = 0;

    public DossierController dossierController;
    public InfoController infoController;
    public BackgroundController backgroundController;
    public InventoryController inventoryController;

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
        backgroundController.ChangeBackground(newBackground);
    }

    public void UpdateInventory(GameObject newInventoryItem)
    {
        inventoryController.UpdateInventory(newInventoryItem);
    }
}
