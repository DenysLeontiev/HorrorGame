using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightHandler : MonoBehaviour
{
    [SerializeField] GameObject lightSource;
    [SerializeField] AudioSource flashLightOnSfx;
    [SerializeField] GameObject actionTextOnOffLight;
    bool isTurnedOn = false;

    void Start()
    {
        actionTextOnOffLight.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !isTurnedOn)
        {
            flashLightOnSfx.Play();
            isTurnedOn = !isTurnedOn;
            lightSource.SetActive(true);
            actionTextOnOffLight.GetComponent<Text>().text = "[P] - вимкнути ліхтарик";
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            actionTextOnOffLight.GetComponent<Text>().text = "[P] - ввімкнути ліхтарик";
            flashLightOnSfx.Play();
            isTurnedOn = !isTurnedOn;
            lightSource.SetActive(false);
        }
    }
}
