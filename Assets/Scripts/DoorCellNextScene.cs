using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorCellNextScene : MonoBehaviour
{
    public float theDistance;
    public GameObject ActionKey;
    public GameObject ActionText;
    public GameObject theDoorToRotate;
    public AudioSource creakSound;
    public GameObject ExtraCross;

    [SerializeField] GameObject fadeOutScreen;
    [SerializeField] int sceneToOpenIndex = 0;

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
                    StartCoroutine(FadeInScreen());
                    // theDoorToRotate.GetComponent<Animation>().Play("FirstDoorOpenAnim");
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

    IEnumerator FadeInScreen()
    {
        fadeOutScreen.SetActive(true);
        // fadeOutScreen.GetComponent<Animation>().Play("FadeOutScreen");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneToOpenIndex);
    }
}
