using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : EnemyKI
{  // Start is called before the first frame update


    private bool soundPlayed = false;
    public AudioClip _ninjaSound;


    protected override void Start()
    {
        base.Start();
    }



    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Distance();
        Gesture();
    }




    public override void Distance()
    {
        base.Distance();
    }

    protected override void Walking()
    {
        if (!anim.GetBool("isRunning"))
            anim.SetFloat("Run", Random.Range(0, 2));


        agent.enabled = true;
        anim.SetBool("isRunning", true);
        anim.SetBool("isAttacking", false);
        agent.SetDestination(target.position);

        if (!soundPlayed)
        {
            audioSource.PlayOneShot(_ninjaSound);
            soundPlayed = true;
        }
    }

    protected override void Attack()
    {
        if (!anim.GetBool("isAttacking"))
            anim.SetFloat("Attacks", Random.Range(0, 5));

        anim.SetBool("isAttacking", true);
        anim.SetBool("Gesture", false);
        anim.SetBool("isRunning", false);


        if (!audioSource.isPlaying)
            AttackSound();
    }

    void Gesture()
    {
       
        
        if (distance <= 10 && distance >= 7)
        {

            if (!anim.GetBool("Gesture"))
                anim.SetFloat("Gesture-Blend", Random.Range(0, 3));

            anim.SetBool("Gesture", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking", false);

            agent.enabled = true;
            agent.SetDestination(target.position);

            


        }
            
          
    }



}
        


    


