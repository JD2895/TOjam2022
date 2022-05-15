using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DossierController : MonoBehaviour
{
    public GameObject[] dossierTabs;

    public Image currentDossierTabImage;
    public Sprite[] allDossierTabImages;

    public void ChangeDossierTab(int newTab)
    {
        for (int i = 0; i < dossierTabs.Length; i++)
        {
            if (i == newTab)
                dossierTabs[i].SetActive(true);
            else
                dossierTabs[i].SetActive(false);
        }

        currentDossierTabImage.sprite = allDossierTabImages[newTab];
    }
}
