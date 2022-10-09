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
    public int zombieDamage = 5;

    GlobalAmmo globalAmmo;

    void Start()
    {
        globalAmmo = FindObjectOfType<GlobalAmmo>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(isFiring == false && GlobalAmmo.AmmoCount > 0)
            {
                StartCoroutine(FiringPistol());
            }
        }
    }

    IEnumerator FiringPistol()
    {
        GlobalAmmo.Shoot();
        isFiring = true;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            targetDistance = hit.distance;
            hit.transform.SendMessage("TakeDamage", zombieDamage, SendMessageOptions.DontRequireReceiver);
        }
        muzzleFlash.SetActive(true);
        fireSfx.Play();
        theGun.GetComponent<Animation>().Play("PistolShot");
        yield return new WaitForSeconds(0.5f);
        muzzleFlash.SetActive(false);
        isFiring = false;
    }
}
