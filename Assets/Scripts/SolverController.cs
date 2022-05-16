using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SolverController : MonoBehaviour
{
    public GameObject[] cases;
    public TextMeshProUGUI[] case1Fills;
    public TextMeshProUGUI[] case2Fills;

    public TextMeshProUGUI case1Response;
    public TextMeshProUGUI case2Response;

    private bool case1solved = false;
    private bool case2solved = false;

    private int currentCase = 0;

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    public void ChangeCase(int changeBy)
    {
        currentCase += changeBy;
        currentCase = currentCase % cases.Length;
        currentCase = Mathf.Abs(currentCase);

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
        if (case1Fills[0].text == "Reese's" && case1Fills[1].text == "A Gift")
        {
            case1Response.text = "That seems right!";
            case1solved = true;
            CheckForEnd();
        }
        else
        {
            case1Response.text = "Hmm something doesn't quite make sense...";
        }
    }

    public void CheckCase2()
    {
        if (case2Fills[0].text == "Dewey" && case2Fills[1].text == "Orange Juice" && case2Fills[2].text == "A Cavity")
        {
            case2Response.text = "That seems right!";
            case2solved = true;
            CheckForEnd();
        }
        else
        {
            case2Response.text = "Hmm something doesn't quite make sense...";
        }
    }

    public void CheckForEnd()
    {
        if (case1solved && case2solved != true)
            return;

        MenuManager.Instance.ShowEnd();
    }
}
