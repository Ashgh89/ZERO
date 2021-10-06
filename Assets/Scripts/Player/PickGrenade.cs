using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGrenade : MonoBehaviour
{
    // private GameObject _grenade;


    public GrenadeThrow _grenade;



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            if(_grenade.currentGrenade<5)
            {
               _grenade.currentGrenade++;

               Destroy(gameObject);
            }
            
            //if (_grenade.currentGrenade < 5)

              

            
            

            

            // grenade.GetComponent<GrenadeThrow>().currentGrenade += 1;
            
        }

       
    }

  

}
