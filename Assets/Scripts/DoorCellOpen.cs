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

    [SerializeField] bool isDoorWithKey = false;
    [SerializeField] AudioSource lockedDoorSFX;
    [SerializeField] GameObject closedDoorText;
    [SerializeField] AudioSource closedDoorVoice;

    public bool IsDoorWithKey
    {
        get
        {
            return IsDoorWithKey;
        }
        set
        {
            isDoorWithKey = value;
        }
    }

    GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;

        RaycastHit hit;
        bool isHit = Physics.Raycast(player.transform.position, player.transform.forward, out hit);

        if(isDoorWithKey && isHit && Vector3.Distance(player.transform.position, transform.position) < 1.75f)
        {
            ActionKey.GetComponent<Text>().text = "[ E ]";
            ActionKey.SetActive(true);
        }
    }

    IEnumerator ClosedDoor()
    {
        lockedDoorSFX.Play();
        closedDoorVoice.Play();
        closedDoorText.SetActive(true);
        ActionText.GetComponent<Text>().text = "Двері закриті,потрібен ключ";
        yield return new WaitForSeconds(1.2f);
        closedDoorText.SetActive(false);
    }

    void OnMouseOver()  // when we are looking at the door
    {
        if(!isOpened)
        {

            if(isDoorWithKey && Input.GetButtonDown("Action"))
            {
                StartCoroutine(ClosedDoor());
                // lockedDoorSFX.Play();
            }
            // OpenDoor();

            if(!isDoorWithKey)
            {
                OpenDoor();
            }
        }
        else
        {
            if(theDistance <= 2f)
            {
                foreach (RawImage rawImage in ExtraCross.GetComponentsInChildren<RawImage>())
                {
                    rawImage.color = Color.green;
                }
                ExtraCross.SetActive(true);
                ActionKey.GetComponent<Text>().text = "[ E ]";
                ActionKey.SetActive(true);
                ActionText.GetComponent<Text>().text = "Зачинити двері";
                ActionText.SetActive(true);
            }

            if(Input.GetButtonDown("Action"))
            {
                print("Action");
                if(theDistance <= 2f)
                {
                    isOpened = false;
                    ActionKey.SetActive(false);
                    ActionText.SetActive(false);
                    theDoorToRotate.GetComponent<Animation>().Play("FirstDoorCloseAnim");
                    creakSound.Play();
                }
            }
        }
    }

    private void OpenDoor()
    {
        if (theDistance <= 2f)
        {
            foreach (RawImage rawImage in ExtraCross.GetComponentsInChildren<RawImage>())
            {
                rawImage.color = Color.green;
            }
            ExtraCross.SetActive(true);
            ActionKey.SetActive(true);
            ActionText.GetComponent<Text>().text = "Відчинити двері";
            ActionText.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (theDistance <= 2f)
            {
                isOpened = true;
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
