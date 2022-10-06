using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
public class Opening001 : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject fadeInScreen;
    public GameObject textBox;

    void Start()
    {
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        fadeInScreen.SetActive(false);
        textBox.GetComponent<Text>().text = "Мені потрібно вибратися звідси!";
        yield return new WaitForSeconds(2f);
        textBox.GetComponent<Text>().text = "";
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
    }
}
