using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float timeDelay = 2f;
    public float radius = 15f;
    float countdown;
    public float force = 700f;
    public GameObject explosionEffect;
    public bool damageOnEnter = false;
    public int damage = 25;
    bool hasExploded = false;




   

    void Start()
    {
        
        countdown = timeDelay;
       
    }




    // Update is called once per frame
    void Update()
    {
        countdown-= Time.deltaTime;
        if (countdown <= 0f && hasExploded == false) 
        {
            Explode();
            
            hasExploded = true;
        }
    }

    void Explode()
    {
        
        GameObject explosionObject = Instantiate(explosionEffect, transform.position, transform.rotation) as GameObject;

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearby in colliders)
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();

            if (rb != null) 
                rb.AddExplosionForce(force, transform.position, radius);
            
            
            ITakeDamage enemy = nearby.GetComponent<ITakeDamage>();

            if (enemy!=null)
                enemy.TakeDamage(20);
            
            
        }

        Destroy(explosionObject, 1.9f);        Destroy(gameObject);
         
    }


}
          

           




  
