using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : EnemyKI
{

    [SerializeField]
    private AudioClip horrorSound;



    protected override void Start()
    {
        base.Start();
    }



    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Distance();
        ZombieIdle();

        if (distance <= 70)
        {
            if (!audioSource.isPlaying)
                HorrorSound();
        }
    }




    public override void Distance()
    {
        base.Distance();
    }

    protected override void Walking()
    {
        if (!anim.GetBool("isWalking"))
            anim.SetFloat("isWalkingg", Random.Range(0, 2));


        agent.enabled = true;
        anim.SetBool("isWalking", true);
        anim.SetBool("isAttacking", false);
        agent.SetDestination(target.position);
    }

    protected override void Attack()
    {
        if (!anim.GetBool("isAttacking"))
            anim.SetFloat("Attacks", Random.Range(0, 2));

        anim.SetBool("isAttacking", true);
        anim.SetBool("isWalking", false);

        if (!audioSource.isPlaying)
            AttackSound();

    }

    void ZombieIdle()
    {

         if (distance <= 500 && distance >= 40)
         {

             if (!anim.GetBool("Idle1"))
             anim.SetFloat("Idle", Random.Range(0, 2));
          
            agent.enabled = false;
            anim.SetBool("Idle1", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
          
         }

    }

    private void HorrorSound()
    {
        audioSource.clip = horrorSound;
        audioSource.volume = 0.4f;
        audioSource.Play();
    }
}


