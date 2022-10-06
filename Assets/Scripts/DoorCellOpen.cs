using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCellOpen : MonoBehaviour
{
    public float theDistance;
    public GameObject ActionKey;
    public GameObject ActionText;
    public GameObject theDoorToRotate;
    public AudioSource creakSound;
    public GameObject ExtraCross;

    void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver()  // when we are looking at the door
    {
        if(theDistance <= 2f)
        {
            foreach (RawImage rawImage in ExtraCross.GetComponentsInChildren<RawImage>())
            {
                rawImage.color = Color.green;
            }
            ExtraCross.SetActive(true);
            ActionKey.SetActive(true);
            ActionText.SetActive(true);
        }

        if(Input.GetButtonDown("Action"))
        {
            if(theDistance <= 2f)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionKey.SetActive(false);
                ActionText.SetActive(false);
                theDoorToRotate.GetComponent<Animation>().Play("FirstDoorOpenAnim");
                creakSound.Play();
            }
        }
    }

    void OnMouseExit() 
    {
        ExtraCross.SetActive(false);
        ActionKey.SetActive(false);
        ActionText.SetActive(false);
    }
}
