using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    

    [SerializeField]
    public GameObject weapon01, weapon02, weapon03;
   
    public Animator p_Animator;
    private AudioSource _audioSource;
   
    public AudioClip _switchSound;

    void Start()
    {

        weapon01.SetActive(true);
        weapon02.SetActive(false);
        weapon03.SetActive(false);

        _audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {

            StartCoroutine(SwitchWaiting2());


           
            Invoke("SwitchSound",0.5f);

          
        }

        if (Input.GetKeyDown("2"))
        {
            StartCoroutine(SwitchWaiting1());
          //  weapon01.SetActive(false);
          // weapon02.SetActive(true);
           Invoke("SwitchSound",0.5f);


        }

        if (Input.GetKeyDown("3"))
        {

            StartCoroutine(SwitchWaiting3());
            Invoke("SwitchSound", 0.5f);


            


        }

    }
    public IEnumerator SwitchWaiting1()
    {
        // weapon01.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        weapon01.SetActive(false);
        weapon03.SetActive(false);

        weapon02.SetActive(true);


    }
    public IEnumerator SwitchWaiting2()
    {
        // weapon01.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        weapon02.SetActive(false);
        weapon03.SetActive(false);

        weapon01.SetActive(true);


    }
    public IEnumerator SwitchWaiting3()
    {
        // weapon01.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        weapon02.SetActive(false);

        weapon01.SetActive(false);
        weapon03.SetActive(true);


    }

    private void SwitchSound()
    {
        _audioSource.clip = _switchSound;
        _audioSource.Play();
    }


   
}

           

            

            



               


            





           


