using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsPickUp : MonoBehaviour
{
    [SerializeField] Transform destination;
    [SerializeField] GameObject theGun;

    [SerializeField] GameObject pickKey;
    [SerializeField] GameObject pickText;

    GameObject player;
    bool isPickedUp = false;
    float distanceBetween;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        RaycastHit hitInfo;
        bool isHit = Physics.Raycast(player.transform.position, transform.forward,out hitInfo);
        distanceBetween = Vector3.Distance(transform.position, player.transform.position);

        // if(distanceBetween < 4f && !isPickedUp)
        // {
        //     pickKey.SetActive(true);

        //     pickText.GetComponent<Text>().text = "Підняти об'єкт(Ліва клавіша мишки)";
        //     pickText.SetActive(true);
        // }
        // else if(isPickedUp)
        // {
        //     // pickKey.SetActive(false);

        //     pickText.GetComponent<Text>().text = "Кинути об'єкт";
        // }
        // else
        // {
        //     pickKey.SetActive(false);
        //     pickText.SetActive(false);
        // }

        // if(distanceBetween < 4f)
        // {
        //     if(Input.GetButtonDown("Action") && !isPickedUp && isHit)
        //     {
        //         PickUp();
        //     }
        //     else if(Input.GetButtonDown("Action") && isPickedUp)
        //     {
        //         PutDown();
        //     }
        // }
    }

    private void PutDown()
    {
        isPickedUp = false;
        this.GetComponent<BoxCollider>().enabled = true;
        this.GetComponent<Rigidbody>().freezeRotation = false;
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.transform.parent = null;
        theGun.SetActive(true);
    }

    private void PickUp()
    {
        isPickedUp = true;
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().freezeRotation = true;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        this.transform.position = destination.position;
        this.transform.parent = GameObject.Find("ObjectDestination").transform;
        theGun.SetActive(false);
    }

    void OnMouseDown()
    {
        if(distanceBetween < 4f)
        {
            PickUp();
        }
    }

    void OnMouseUp()
    {
        PutDown();
    }
}
