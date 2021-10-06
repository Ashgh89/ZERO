using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDamage : MonoBehaviour
{

    public GameObject damageUI;
    public AudioClip painSound;
    public AudioClip axeSound;

    private AudioSource _audioSource;
    


    private void Start()
    {
        // damageUI.SetActive(false);
        _audioSource = GetComponent<AudioSource>();

    }


    private void OnTriggerEnter(Collider other)
    {



        

             if (other.gameObject.tag == "Player") 
             {
                 other.GetComponent<PlayerHealth>().p_TakeDamage(20);
                 playerPainSound();
                 damageUI.SetActive(true);
                    Debug.Log("Damage");
             }
            else
            damageUI.SetActive(false);




        //else if (other.GetType() == typeof(BoxCollider)&& other.gameObject.tag == "Environment")
        //{
        //      AxeSound();
        //}

        if (other.gameObject.tag=="Environment")
        {
            if (!_audioSource.isPlaying)
                AxeSound();
        }
       

      



    }

    public void playerPainSound()
    {
        _audioSource.clip = painSound;
        _audioSource.Play();
    }

    private void AxeSound()
    {
        _audioSource.clip = axeSound;
        _audioSource.Play();
    }


    //   if (collision.gameObject.tag=="Player")
    //   {
    //       
    //       Debug.Log("HI");
    //   }
    //

}
