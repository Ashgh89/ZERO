using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemyHealth : MonoBehaviour, ITakeDamage
{
    public int maxHealth = 100;
    public int currentHealth;
    private Slider slider;
    EnemyKI enemyKI;
    public GameObject showLadder;
    private bool isDead;
    private void Start()
    {

        slider = (Slider)FindObjectOfType(typeof(Slider));    
        enemyKI = GetComponent<EnemyKI>();
        currentHealth = maxHealth;
        slider.value = currentHealth;
        showLadder.SetActive(false);
        
    }

     void Die()
     {
        enemyKI.DeathAnim();
        Destroy(gameObject, 5);
     }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;

        if (currentHealth <= 0 && !isDead) 
        {
            isDead = true;
            currentHealth = 0;
            Die();
            showLadder.SetActive(true);
           
        }
           
    }

}


   
