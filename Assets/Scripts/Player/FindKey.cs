using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FindKey : MonoBehaviour
{

    private GameObject[] zombies;
    public GameObject _key;

   


    private void Start()
    {
        
        _key.SetActive(false);
    }


    private void Update()
    {
        
          zombies = GameObject.FindGameObjectsWithTag("Zombie"); // Checks if enemies are available with tag "Enemy". Note that you should set this to your enemies in the inspector.
          if (zombies.Length == 0)
          {
              _key.SetActive(true);
          }
    }

 



}
