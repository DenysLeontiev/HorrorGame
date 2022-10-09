using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieDeath : MonoBehaviour
{
    public int enemyHealth = 25;
    Animator animator;
    NavMeshAgent navMeshAgent;

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("die");
        this.GetComponent<CapsuleCollider>().enabled = false;
        // GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        navMeshAgent.isStopped = true;
        // navMeshAgent.enabled = false;
        // this.enabled = false;
        Destroy(this.gameObject, 2f);
    }

    public void TakeDamage(int zombieDamage)
    {
        enemyHealth -= zombieDamage;
    }
}
