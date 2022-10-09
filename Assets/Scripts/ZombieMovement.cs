using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] GameObject target;
    NavMeshAgent meshAgent;

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
                GetComponent<Animator>().SetBool("attack", true);

                meshAgent.isStopped = true;
                speed = 0;
            }
        }
    }

    private float GetLocalSpeed()
    {
        // transform.LookAt(target.transform);
        return transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z;
    }
}
