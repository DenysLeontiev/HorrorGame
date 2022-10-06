using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class FirstTrigger002 : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject textBox;
    public GameObject theMarker;

    bool isTriggered = false;

    void OnTriggerEnter()
    {
        if(isTriggered == false)
        {
            isTriggered = true;
            thePlayer.GetComponent<FirstPersonController>().enabled = false;
            StartCoroutine(ScenePlayer());
        }
    }

    IEnumerator ScenePlayer()
    {
        textBox.GetComponent<Text>().text = "Ойойой!Пістолет на столі,damn!";
        yield return new WaitForSeconds(2.5f);
        textBox.GetComponent<Text>().text = "";
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
        theMarker.SetActive(true);
    }
}
