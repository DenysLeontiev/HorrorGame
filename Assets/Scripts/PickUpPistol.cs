using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPistol : MonoBehaviour
{
    public float theDistance;
    public GameObject ActionKey;
    public GameObject ActionText;
    public GameObject fakePistol;
    public GameObject realPistol;
    public GameObject guideArrow;
    public GameObject extraCross;
    public GameObject jumpTrigger;

    void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver() 
    {
        if(theDistance <= 2f)
        {
            foreach (RawImage rawImage in extraCross.GetComponentsInChildren<RawImage>())
            {
                rawImage.color = Color.green;
            }
            extraCross.SetActive(true);
            ActionKey.SetActive(true);
            ActionText.GetComponent<Text>().text = "Підняти пістолет";
            ActionText.SetActive(true);
            jumpTrigger.SetActive(true);
        }

        if(Input.GetButtonDown("Action"))
        {
            if(theDistance <= 2f)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionKey.SetActive(false);
                ActionText.SetActive(false);
                fakePistol.SetActive(false);
                realPistol.SetActive(true);
                extraCross.SetActive(false);
                guideArrow.SetActive(false);
            }
        }
    }

    void OnMouseExit() 
    {
        extraCross.SetActive(false);
        ActionKey.SetActive(false);
        ActionText.SetActive(false);
    }
}
