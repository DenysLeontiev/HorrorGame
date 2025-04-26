using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightPickUp : MonoBehaviour
{
    [SerializeField] GameObject actionKey;
    [SerializeField] GameObject actionText;
    [SerializeField] GameObject fakeFlashLight;
    [SerializeField] GameObject realFlashLight;
    [SerializeField] AudioSource pickUpSfx;

    GameObject player;
    bool canPickUp = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float distanceBetween = Vector3.Distance(transform.position, player.transform.position);
        RaycastHit hit;
        bool isHit = Physics.Raycast(player.transform.position, transform.forward, out hit);
        if(distanceBetween <= 3.1f && this.transform.name.Contains("Flash"))
        {
            actionKey.SetActive(true);
            actionText.GetComponent<Text>().text = "Підняти ліхтарик";
            actionText.SetActive(true);
        }
        else
        {
            actionKey.SetActive(false);
            actionText.SetActive(false);
        }

        if(distanceBetween <= 3.1f && Input.GetButtonDown("Action"))
        {
            pickUpSfx.Play();
            fakeFlashLight.SetActive(false);
            realFlashLight.SetActive(true);
            actionKey.SetActive(false);
            actionText.SetActive(false);
            this.enabled = false;
        }
    }

    
}
