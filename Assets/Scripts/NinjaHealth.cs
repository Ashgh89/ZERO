using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NinjaHealth : MonoBehaviour, ITakeDamage
{
    public int maxHealth = 100;
    public int currentHealth;
    EnemyKI enemyKI;
    public Slider slider;
    public bool ninjaIsDead = false;


    // Start is called before the first frame update
    void Start()
    {
        enemyKI = GetComponent<EnemyKI>();
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (ninjaIsDead)
         Invoke("EndGame",6f);
        
    }
        
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;

        if (currentHealth <= 0 && !ninjaIsDead)
        {

            ninjaIsDead = true;
            Die();


        }
    }

    void Die()
    {

        enemyKI.DeathAnim();
        Destroy(gameObject, 7);
    }

    void EndGame()
    {
        SceneManager.LoadScene("Win");
    }

}
