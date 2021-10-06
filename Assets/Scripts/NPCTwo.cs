using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTwo : MonoBehaviour
{

    public GameObject UI;
    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            UI.SetActive(true);
        }


    }
    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            UI.SetActive(false);
        }


    }
    private void Update()
    {
     
        Vector3 pos = target.position - transform.position;
        pos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = rotation;

    }
}
