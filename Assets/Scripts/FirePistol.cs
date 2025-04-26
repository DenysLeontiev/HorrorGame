using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    [SerializeField] GameObject shootPosition;

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
        if(Physics.Raycast(transform.position, shootPosition.transform.forward, out hit))
        {
            print(hit.transform.name);
            // if(hit.transform.tag != "Breakable")
            // {
                targetDistance = hit.distance;
                hit.transform.SendMessage("TakeDamage", zombieDamage, SendMessageOptions.DontRequireReceiver);
                if(hit.transform.GetComponent<BossHealth>() != null)
                {
                    hit.transform.GetComponent<BossHealth>().TakeDamageFromBoss(5);
                }
            // }
            
            if(hit.transform.tag == "Breakable")
            {
                hit.transform.GetComponent<BreakAbleObject>().breakableIsHit = true;
            }
        }
        muzzleFlash.SetActive(true);
        fireSfx.Play();
        theGun.GetComponent<Animation>().Play("PistolShot");
        yield return new WaitForSeconds(0.5f);
        muzzleFlash.SetActive(false);
        isFiring = false;
    }
}
