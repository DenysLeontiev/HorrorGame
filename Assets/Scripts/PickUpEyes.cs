using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PickUpEyes : MonoBehaviour
{
    public float theDistanceEyes;
    public GameObject ActionKey;
    public GameObject ActionText;
    public GameObject extraCross;
    public GameObject firstNoteEye;

    [SerializeField] AudioSource letterSfx;

    [SerializeField] GameObject panelPickedUpEye;
    [SerializeField] GameObject thePlayer;

    [SerializeField] GameObject eyeText;

    [SerializeField] string actionText;
    [SerializeField] string eyeTextPickedUp;

    void Update()
    {
        theDistanceEyes = PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver() 
    {
        if(theDistanceEyes <= 2f)
        {
            foreach (RawImage rawImage in extraCross.GetComponentsInChildren<RawImage>())
            {
                rawImage.color = Color.green;
            }
            eyeText.GetComponent<Text>().text = eyeTextPickedUp;
            extraCross.SetActive(true);
            ActionKey.SetActive(true);
            // ActionKey.GetComponent<Text>().text = actionKeyText;
            ActionText.GetComponent<Text>().text = actionText;
            ActionText.SetActive(true);
        }

        if(Input.GetButtonDown("Action"))
        {
            if(theDistanceEyes <= 2f)
            {
                if(this.transform.name.ToLower().Contains("first"))
                {
                    GlobalInventory.firstPictureOfEye = true;
                }
                else if(this.transform.name.ToLower().Contains("second"))
                {
                    GlobalInventory.secondPictureOfEye = true;
                }

                letterSfx.Play();
                StartCoroutine(ShowPickUp());
                this.GetComponent<BoxCollider>().enabled = false;
                firstNoteEye.SetActive(false);
                ActionKey.SetActive(false);
                ActionText.SetActive(false);
                extraCross.SetActive(false);
                // GlobalInventory.firstPictureOfEye = true;
            }
        }
    }

    void OnMouseExit() 
    {
        extraCross.SetActive(false);
        ActionKey.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator ShowPickUp()
    {
        panelPickedUpEye.SetActive(true);
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        yield return new WaitForSeconds(3f);
        panelPickedUpEye.SetActive(false);
        thePlayer.GetComponent<FirstPersonController>().enabled = true;

    }
}
