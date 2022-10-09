using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] GameObject panelToDisplayAmmo;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            this.gameObject.SetActive(false);
            panelToDisplayAmmo.SetActive(true);
            GlobalAmmo.PickUpAmmo(5);
        }
    }
}
