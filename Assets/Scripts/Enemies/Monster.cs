using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : EnemyKI
{
    // Start is called before the first frame update


    protected override void Start()
    {
        base.Start();
    }

   
    
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Distance();
    }
   



    public override void Distance()
    {
        base.Distance();
    }

    protected override void Walking()
    {
        if (!anim.GetBool("isWalking"))
            anim.SetFloat("Run", Random.Range(0, 2));


        agent.enabled = true;
        anim.SetBool("isWalking", true);
        anim.SetBool("isAttacking", false);
        agent.SetDestination(target.position);
    }

    protected override void Attack()
    {
        if (!anim.GetBool("isAttacking"))
            anim.SetFloat("Attacks", Random.Range(0, 5));

        anim.SetBool("isAttacking", true);

        if (!audioSource.isPlaying)
            AttackSound();
    }


}
