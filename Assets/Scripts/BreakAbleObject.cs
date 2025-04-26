using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAbleObject : MonoBehaviour
{
    [SerializeField] GameObject breakAbleObject;

    public AudioSource breakBoxSFX;
    public AudioSource breakBottleSFX;

    public  bool breakableIsHit;

    [SerializeField] bool isBottle;

    [SerializeField] bool isKeyInThere;
    [SerializeField] GameObject keyToSpawn;
    [SerializeField] float keySpawnPosY = 0.3f;

    void Update()
    {
        if(breakableIsHit)
        {
            if(isKeyInThere)
            {
                // Instantiate(keyToSpawn, new Vector3(transform.position.x, transform.position.y + keySpawnPosY, transform.position.z), Quaternion.identity);
            }

            if(isBottle)
            {
                breakBottleSFX.Play();
            }
            else
            {
                breakBoxSFX.Play();
            }
            Instantiate(breakAbleObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
