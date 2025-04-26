using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    [SerializeField] int bossDamage = 5;
    [SerializeField] CameraShake cameraToShake;

    [SerializeField] AudioSource hurtSFX001;
    [SerializeField] AudioSource hurtSFX002;
    [SerializeField] AudioSource hurtSFX003;

    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void BossDamagePlayer() // Animation event
    {
        print("Damaging");
        player.GetComponent<PlayerHealth>().DamagePlayer(bossDamage);
        PlayHurtPlayerSfx();
        // FindObjectOfType<CameraShake>().ShakeCamera(0.2f, 0.3f);
        StartCoroutine(cameraToShake.ShakeCamera(0.2f,0.3f));
    }

    void PlayHurtPlayerSfx()
    {
        int randomHitSFX = Random.Range(1,4);
        if(randomHitSFX == 1)
        {
            hurtSFX001.Play();
        }
        else if(randomHitSFX == 2)
        {
            hurtSFX002.Play();
        }
        else if(randomHitSFX == 3)
        {
            hurtSFX003.Play();
        }
    }
}
