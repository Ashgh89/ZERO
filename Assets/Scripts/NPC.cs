using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    
    public Animator _NPC;
    public float volume;
    private AudioSource _audioSource;
    public AudioClip playSound;
    public bool alreadyPlayed = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" && !alreadyPlayed) 
        {
          _NPC.SetBool("Point", true);

            Invoke("Sound", 1f);
           alreadyPlayed = true;

        }
      
    }
       
    private void Sound()
    {
        _audioSource.PlayOneShot(playSound, volume);

    }
}


 
       
