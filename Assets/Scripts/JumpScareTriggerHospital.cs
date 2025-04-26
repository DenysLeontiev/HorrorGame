using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareTriggerHospital : MonoBehaviour
{
    [SerializeField] GameObject zombieTrigger;
    [SerializeField] AudioSource jumpTriggerSFX;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            zombieTrigger.SetActive(true);
            jumpTriggerSFX.Play();
            Destroy(zombieTrigger, 1f);
        }
    }
}
