using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject[] backgrounds;

    public void ChangeBackground(GameObject newBackground)
    {
        if (!Array.Exists(backgrounds, b => b.name == newBackground.name))
        {
            Debug.LogError("No background found for: " + newBackground.name);
            return;
        }
        else
        {
            for(int i = 0; i < backgrounds.Length; i++)
            {
                if (backgrounds[i].name == newBackground.name)
                    backgrounds[i].SetActive(true);
                else
                    backgrounds[i].SetActive(false);
            }
        }
    }
}
