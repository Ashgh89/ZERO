using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeThrow : MonoBehaviour
{

    public int maxGrenade = 2;
    public int currentGrenade=2;
    public bool noGrenade = false;
    public Text grenadeText;
    public GameObject alertGrenade;

    public float throwForce = 10f;
    public GameObject grenadePrefab;
    private AudioSource _audioSource;
   //public GameObject grenade_Pick;

    public AudioClip _grenadeSound;

    // Start is called before the first frame update
   public void Start()
    {
        currentGrenade = maxGrenade;
        _audioSource = GetComponent<AudioSource>();
        alertGrenade.SetActive(false);

    }

    // Update is called once per frame
   public void Update()
    {
        //MaxGrenade();

        if (Time.timeScale != 0)
            if (Input.GetKeyDown(KeyCode.G)&&!noGrenade)
            {
               ThrowGrenade();
               Invoke("GrenadeSound", 2f);

            }
      
        if(Input.GetKeyDown(KeyCode.G)&& currentGrenade<=0)
        {
            noGrenade = true;
            alertGrenade.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.G))
            alertGrenade.SetActive(false);

        grenadeText.text = currentGrenade + "/" + maxGrenade;
       
    }

    public void ThrowGrenade()
    {

      
        
           
          
          GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
          currentGrenade--;
          //Forward Force to our Grenade
          Rigidbody rb = grenade.GetComponent<Rigidbody>();
          rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
          
            
    }

  // private void OnTriggerEnter(Collider other)
  // {
  //     if (other.gameObject.tag == "Pickups")
  //     {
  //         if (currentGrenade<5)
  //         {
  //            GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
  //
  //
  //             Destroy(other.gameObject);
  //         }
  //
  //
  //     }
  // }
  //
   public void MaxGrenade()
    {
        if (currentGrenade > 2)
            currentGrenade = 2;
    }

    private void GrenadeSound()
   {
       _audioSource.clip = _grenadeSound;
       _audioSource.Play();
   }

 //  private void OnTriggerEnter(Collider other)
 //  {
 //      if (other.gameObject.tag == "Grenade")
 //      {
 //           if (currentGrenade < 5)
 //           {
 //              currentGrenade += 1;
 //
 //              Destroy(other.gameObject);
 //              Debug.Log("Works");
 //           }
 //          
 //
 //          
 //
 //         
 //
 //      }
 //
 //
 //  }
 //

}
