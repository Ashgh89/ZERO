using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : EnemyKI
{
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
        if (!anim.GetBool("isRunning"))
            anim.SetFloat("Running", Random.Range(0, 3));


        agent.enabled = true;
        anim.SetBool("isRunning", true);
        agent.SetDestination(target.position);
       
    }

   protected override void Attack()
   {
     
   }
  
     
  
      
  
      

}
