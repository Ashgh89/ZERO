﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Hit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
  
  
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().p_TakeDamage(50);
  
            Debug.Log("hi");
        }
  
    }
  
  
  
}
  
  
  
  
  
  
  
  
