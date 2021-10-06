using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeVolume : MonoBehaviour
{

    private AudioSource audioSource;

    private float musivVolume = 1f;

     void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        audioSource.volume = musivVolume;
    }


    public void SetVolume(float vol)
    {
        musivVolume = vol;
    }
}
