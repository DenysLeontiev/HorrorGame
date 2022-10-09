using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger003 : MonoBehaviour
{
    public GameObject doorToOpen;
    public GameObject zombie;
    public AudioSource doorBangSfx;
    public AudioSource doorJumpMusic;

    void OnTriggerEnter()
    {
        print("lol");
        this.GetComponent<BoxCollider>().enabled = false;
        doorToOpen.GetComponent<Animation>().Play("DoorWithZombieAnim");
        doorBangSfx.Play();
        zombie.SetActive(true);
        StartCoroutine(PlayJumpMusic());
    }

    IEnumerator PlayJumpMusic()
    {
        yield return new WaitForSeconds(0.4f);
        doorJumpMusic.Play();
    }
}
