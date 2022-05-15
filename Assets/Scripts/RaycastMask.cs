using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastMask : MonoBehaviour
{
    public float alphaThreshold;

    void Start()
    {
        this.GetComponent<Button>().image.alphaHitTestMinimumThreshold = alphaThreshold;
    }
}
