using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{

    public GameObject showUI;
    private AudioSource audioSource;
    private bool UIplayed = false;

    
    // Start is called before the first frame update
    void Start()
    {
        showUI.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player" && !UIplayed) 
        {
            showUI.SetActive(true);
            audioSource.Play();
            StartCoroutine(Waiting());
            UIplayed = true;
        }


    }
        
    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(6.5f);
          Destroy(gameObject);
          Destroy(showUI);
    }

}


