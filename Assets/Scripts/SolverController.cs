using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SolverController : MonoBehaviour
{
    public GameObject[] cases;
    public TextMeshProUGUI[] case1Fills;

    private int currentCase = 0;

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    public void ChangeCase(int changeBy)
    {
        currentCase += changeBy;
        currentCase = currentCase % cases.Length;

        for (int i = 0; i < cases.Length; i++)
        {
            if (i == currentCase)
                cases[i].SetActive(true);
            else
                cases[i].SetActive(false);
        }
    }

    public void CheckCase1()
    {
        if (case1Fills[0].text == "Option 1" && case1Fills[1].text == "Option 2")
        {
            Debug.Log("Case 1 correct!");
        }
        else
        {
            Debug.Log("Case 1 has something missing...");
        }
    }
}
