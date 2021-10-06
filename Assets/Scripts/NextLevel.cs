using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
    private GameObject[] enemies;
   


  

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Alien"); 
        if (enemies.Length == 0)
        {
           
            Invoke("DelayAction", 4);
        }
    }
   
    void DelayAction()
    {
        SceneManager.LoadScene("Lvl3"); // Load the scene with name "OtherSceneName"

    }
}
