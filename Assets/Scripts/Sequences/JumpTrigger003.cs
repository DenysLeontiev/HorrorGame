using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger003 : MonoBehaviour
{
    public GameObject doorToOpen;
    public GameObject zombie;
    public AudioSource doorBangSfx;
    public AudioSource doorJumpMusic;

    public AudioSource ambientMusic;

    void Start()
    {
        
    }

    void OnTriggerEnter()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        doorToOpen.GetComponent<Animation>().Play("DoorWithZombieAnim");
        doorBangSfx.Play();
        ambientMusic.Pause();
        zombie.SetActive(true);
        StartCoroutine(PlayJumpMusic());
    }

    IEnumerator PlayJumpMusic()
    {
        yield return new WaitForSeconds(0.4f);
        doorJumpMusic.Play();
    }
}
