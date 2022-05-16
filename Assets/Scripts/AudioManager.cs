using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public Transform flipContainer;
    private List<AudioSource> pageFlips = new List<AudioSource>();

    public static AudioManager Instance
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

        foreach (Transform child in flipContainer)
        {
            pageFlips.Add(child.GetComponent<AudioSource>());
        }

        AudioListener.volume = 0.5f;
    }

    public void PageFlip()
    {
        pageFlips[Random.Range(0, 8)].Play();
    }

    public void ChangeVolume(float newVolume)
    {
        AudioListener.volume = newVolume;
    }
}
