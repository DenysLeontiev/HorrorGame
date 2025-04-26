using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossScript : MonoBehaviour
{
    [SerializeField] GameObject player;

    NavMeshAgent navMeshAgent;
    Animator animator;

    float localSpeed;

    bool isTimeToAttack;

    bool isReadyToAttack = false;
    public bool IsReadyToAttack
    {
        get
        {
            return isReadyToAttack;
        }
        set
        {
            isReadyToAttack = value;
        }
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetComponent<Rigidbody>().freezeRotation = !isReadyToAttack;
        if(isReadyToAttack == false)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

        if(isReadyToAttack == false) return;

        localSpeed = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z;
        PlayAnimation();

        float distanceBetween = Vector3.Distance(transform.position, player.transform.position);

        if(distanceBetween >= 3.3f)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.destination = player.transform.position;
            // animator.SetBool("attack", false);
            // animator.ResetTrigger("att");
        }
        else if(distanceBetween < 3.3f)
        {
            animator.SetTrigger("att");
            // animator.SetBool("attack", true);
            GetComponent<Rigidbody>().freezeRotation = true;
            navMeshAgent.isStopped = true;
        }
    }

    private void PlayAnimation()
    {
        float testSpeed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("bossSpeed", testSpeed);
    }

    public void HitPLayer()
    {
        print("hit");
        // player.GetComponent<PlayerHealth>().DamagePlayer(5);
    }
}
