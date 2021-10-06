using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class DamageEntity : MonoBehaviour
{
    public float damage = 4f;
    public bool damageOnEnter = false;
    public bool damageOnExit =false;
    public bool damageOnStay = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(damageOnEnter)
        {
            if (other.GetComponent<PlayerHealth>() != null)
            {
                other.GetComponent<PlayerHealth>().p_TakeDamage(damage);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(damageOnExit)
        {
            if (other.GetComponent<PlayerHealth>() != null)
            {
                other.GetComponent<PlayerHealth>().p_TakeDamage(damage);

            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            other.GetComponent<PlayerHealth>().p_TakeDamage(damage*Time.deltaTime);

        }
    }
}
