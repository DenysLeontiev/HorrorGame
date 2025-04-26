using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class NotePickup : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject noteShow;

    [SerializeField] GameObject ActionKey;
    [SerializeField] GameObject ActionText;

    [SerializeField] AudioSource paperPickupSfx;

    bool isPickedUp = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        bool isHit = Physics.Raycast(player.transform.position, player.transform.forward, out RaycastHit hit);
        if(distance <= 4f)
        {
            ActionKey.SetActive(true);
            ActionText.SetActive(true);
        }
        if(distance <= 4f && isHit && hit.transform.tag == "Note")
        {
            if(Input.GetButtonDown("Action") && !isPickedUp)
            {
                GameObject.FindWithTag("RealNote").GetComponent<MeshRenderer>().enabled = false;
                paperPickupSfx.Play();
                isPickedUp = true;
                player.transform.GetComponent<FirstPersonController>().enabled = false;
                ActionText.GetComponent<Text>().text = "Покласти записку";
                noteShow.SetActive(true);
            }
            else if(Input.GetButtonDown("Action") && isPickedUp)
            {
                GameObject.FindWithTag("RealNote").GetComponent<MeshRenderer>().enabled = true;
                paperPickupSfx.Play();
                isPickedUp = false;
                player.transform.GetComponent<FirstPersonController>().enabled = true;
                ActionText.GetComponent<Text>().text = "Підняти записку";
                noteShow.SetActive(false);
            }
        }
        else
        {
            ActionKey.SetActive(false);
            ActionText.SetActive(false);
        }
    }
}
