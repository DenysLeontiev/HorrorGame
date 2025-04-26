using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] AudioSource clownCreakSFX;
    [SerializeField] AudioSource clownLaughSFX;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            clownCreakSFX.Play();
            StartCoroutine(StartClownLaugh());
            boss.GetComponent<Rigidbody>().freezeRotation = true;
            boss.GetComponent<BossScript>().IsReadyToAttack = true;
        }
    }

    IEnumerator StartClownLaugh()
    {
        yield return new WaitForSeconds(1.6f);
        clownLaughSFX.Play();
    }
}
