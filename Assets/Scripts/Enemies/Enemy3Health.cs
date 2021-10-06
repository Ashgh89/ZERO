using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy3Health : MonoBehaviour, ITakeDamage
{

    public int maxHealth = 10;
    public int currentHealth;
    EnemyKI enemyKI;
    private bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        enemyKI = GetComponent<EnemyKI>();
        currentHealth = maxHealth;
        
    }

  
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        if (currentHealth <= 0&&!isDead)
        {

            currentHealth = 0;
            isDead = true;
            Die();


        }

    }


   void Die()
   {

       enemyKI.DeathAnim();
       Destroy(gameObject, 2);
   }

}




















