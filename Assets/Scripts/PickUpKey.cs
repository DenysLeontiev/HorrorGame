using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    [SerializeField] GameObject doorWithKey;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GlobalInventory.firstMansionDoorKey = true;

            this.gameObject.SetActive(false);
            doorWithKey.GetComponent<DoorCellOpen>().IsDoorWithKey = false;
        }
    }
}
