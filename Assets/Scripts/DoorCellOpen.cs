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

    [SerializeField] bool isOpened = false;

    void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver()  // when we are looking at the door
    {
        if(!isOpened)
        {
            if(theDistance <= 2f)
            {
                foreach (RawImage rawImage in ExtraCross.GetComponentsInChildren<RawImage>())
                {
                    rawImage.color = Color.green;
                }
                ExtraCross.SetActive(true);
                ActionKey.SetActive(true);
                ActionText.GetComponent<Text>().text = "To open the door";
                ActionText.SetActive(true);
            }

            if(Input.GetButtonDown("Action"))
            {
                if(theDistance <= 2f)
                {
                    isOpened = true;
                    ActionKey.SetActive(false);
                    ActionText.SetActive(false);
                    theDoorToRotate.GetComponent<Animation>().Play("FirstDoorOpenAnim");
                    creakSound.Play();
                }
            }
        }
        else
        {
            print("else");
            if(theDistance <= 2f)
            {
                print("first if");
                foreach (RawImage rawImage in ExtraCross.GetComponentsInChildren<RawImage>())
                {
                    rawImage.color = Color.green;
                }
                ExtraCross.SetActive(true);
                ActionKey.GetComponent<Text>().text = "[E]";
                ActionKey.SetActive(true);
                ActionText.GetComponent<Text>().text = "To close the door";
                ActionText.SetActive(true);
            }

            if(Input.GetButtonDown("Action"))
            {
                print("Action");
                if(theDistance <= 2f)
                {
                    print("secondIf");
                    isOpened = false;
                    ActionKey.SetActive(false);
                    ActionText.SetActive(false);
                    theDoorToRotate.GetComponent<Animation>().Play("FirstDoorCloseAnim");
                    creakSound.Play();
                }
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
