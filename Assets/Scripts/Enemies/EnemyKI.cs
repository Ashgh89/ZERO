using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class EnemyKI : MonoBehaviour
{
   protected NavMeshAgent agent;
   protected Transform target;

    [SerializeField]
    protected Animator anim;

    bool isDead = false;

    
    protected AudioSource audioSource;

 // [SerializeField]
 // protected AudioClip walkingSound;

    [SerializeField]
    protected AudioClip[] deadSound;

    [SerializeField]
    protected AudioClip[] attackSound;

    protected float distance;

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    protected virtual void Update()
    {

        Vector3 lookVector = target.transform.position - transform.position;
        lookVector.y = 0;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.5f);
        distance = Vector3.Distance(transform.position, target.position);
    }

    public virtual void Distance()
    {



        if(!isDead)
        {
            if (distance <= 58 && distance >= 10 && !isDead)
            {

                agent.enabled = true;

                Walking();

            }

            else if (distance <= 6 && distance >= 2 && !isDead)
            {

                agent.enabled = false;

                Attack();

            }

        }
       



    }

    public void DeathAnim()
    {
        isDead = true;
        DeadSound();
        agent.enabled = false;
        anim.SetTrigger("isDead");
        DeadSound();
    }


    protected abstract void Walking();
    protected abstract void Attack();
    


    protected void AttackSound()
    {
        audioSource.clip = attackSound[Random.Range(0, attackSound.Length)];
        audioSource.Play();
    }


    protected void DeadSound()
    {
        audioSource.clip = deadSound[Random.Range(0, deadSound.Length)];
        audioSource.volume = 1f;
        audioSource.Play();
    }
}
