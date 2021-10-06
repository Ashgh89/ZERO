using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public float currentHealth = 100;
    public float maxHealth = 100;
    public Slider slider;
    //  public GameObject HP_Pickup;
    private AudioSource _audioSource;
    public AudioClip deadSound;

    

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    private void Update()
    {
        MaxHealth();

    }



    public void p_TakeDamage(float amount)
    {
        currentHealth -= amount;
        slider.value = currentHealth;

        if (currentHealth <= 0)
        {
            
            playerDeadSound();
            Debug.Log("Game Over");
            Destroy(gameObject, 2);
            Invoke("DelayedAction", 1.5f);
            Cursor.lockState = CursorLockMode.None;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickups")
        {
            if (currentHealth < 100)
            {
                currentHealth += 15;
                slider.value += 15;
                Destroy(other.gameObject);
                Debug.Log("it Works");
            }



        }



    }
    void MaxHealth()
    {
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
    }


    private void playerDeadSound()
    {
        _audioSource.clip = deadSound;
        _audioSource.Play();
    }

    void DelayedAction()
    {
        SceneManager.LoadScene("GameOver");


    }

   

}