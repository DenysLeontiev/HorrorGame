using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject muzzleFlash;
    public GameObject theGun;
    public AudioSource fireSfx;
    bool isFiring = false;
    public float targetDistance;
    public int zombieDamage;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(isFiring == false)
            {
                StartCoroutine(FiringPistol());
            }
        }
    }

    IEnumerator FiringPistol()
    {
        isFiring = true;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            targetDistance = hit.distance;
            hit.transform.SendMessage("DamageZombie", zombieDamage, SendMessageOptions.DontRequireReceiver);
            print(hit.transform.name);
        }
        muzzleFlash.SetActive(true);
        fireSfx.Play();
        theGun.GetComponent<Animation>().Play("PistolShot");
        yield return new WaitForSeconds(0.5f);
        muzzleFlash.SetActive(false);
        isFiring = false;
    }
}