using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;




public class ToLvl2 : MonoBehaviour
{
    public bool _pickKey = false;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _pickKey = true;
            Invoke("DelayedAction", 4);


        }
    }
    void DelayedAction()
    {
        SceneManager.LoadScene("Lvl2");
    }
}
