using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] GameObject target;
    NavMeshAgent meshAgent;
    [SerializeField] int zombieDamage = 5;
    [SerializeField] AudioSource hurtSFX001;
    [SerializeField] AudioSource hurtSFX002;
    [SerializeField] AudioSource hurtSFX003;
    

    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(this.GetComponent<ZombieDeath>().enemyHealth > 0)
        {
            float speed = GetLocalSpeed();
            GetComponent<Animator>().SetFloat("zombieSpeed", speed);

            if (Vector3.Distance(transform.position, target.transform.position) > 2.2f)
            {
                meshAgent.destination = target.transform.position;
                meshAgent.isStopped = false;
                GetComponent<Animator>().SetBool("attack", false);
            }
            else
            {
                Attack();
                // StartCoroutine(HitPlayer(zombieDamage));
                // speed = 0;
            }
        }
    }

    public void HitPlayer(int damage)  // Animation Event(REAL ONE!!!!)
    {
        target.GetComponent<PlayerHealth>().DamagePlayer(zombieDamage);

        int randomHitSFX = Random.Range(1,4);
        print(randomHitSFX);
        if(randomHitSFX == 1)
        {
            hurtSFX001.Play();
        }
        else if(randomHitSFX == 2)
        {
            hurtSFX002.Play();
        }
        else if(randomHitSFX == 3)
        {
            hurtSFX003.Play();
        }
    }

    private void Attack()
    {
        GetComponent<Animator>().SetBool("attack", true);
        meshAgent.isStopped = true;
    }

    private float GetLocalSpeed()
    {
        // transform.LookAt(target.transform);
        return transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z;
    }
}
