using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kicking : MonoBehaviour
{
   
    
    

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
            Debug.Log("Damage");
        }
            
    }
          
}


   



       

        

      








   
