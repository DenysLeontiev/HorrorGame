using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampFallDown : MonoBehaviour
{
    [SerializeField] AudioSource dropLampSfx;
    bool isEntered = false;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "LampDropSound" && !isEntered)
        {
            isEntered = true;
            dropLampSfx.Play();
        }
    }
}
