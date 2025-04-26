using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeHandler : MonoBehaviour
{
    [SerializeField] GameObject actionKey;
    [SerializeField] GameObject actionText;
    [SerializeField] GameObject eyeToShow;
    [SerializeField] GameObject slideWall;
    [SerializeField] AudioSource stoneDoorOpenSfx;

    GameObject player;
    bool isDoorActivated = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= 3f)
        {
            actionKey.SetActive(true);

            if(GlobalInventory.firstPictureOfEye && GlobalInventory.secondPictureOfEye)
            {
                actionText.GetComponent<Text>().text = "Активувати двері";
            }
            else
            {
                actionText.GetComponent<Text>().text = "Потрібно знайти усі фрагменти ока";
            }
            actionText.SetActive(true);

            if(Input.GetButtonDown("Action") && GlobalInventory.firstPictureOfEye && GlobalInventory.secondPictureOfEye && !isDoorActivated)
            {
                isDoorActivated = true;
                stoneDoorOpenSfx.Play();
                eyeToShow.SetActive(true);
                slideWall.GetComponent<Animator>().SetTrigger("slide");
            }
        }
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        actionText.SetActive(false);
    }
}
