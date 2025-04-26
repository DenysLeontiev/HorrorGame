using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLampTrigger : MonoBehaviour
{
    [SerializeField] GameObject sphereTrigger;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sphereTrigger.SetActive(true);
            this.GetComponent<BoxCollider>().enabled = false;
            Destroy(sphereTrigger, 1f);
        }
    }
}
