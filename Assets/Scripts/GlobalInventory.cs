using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInventory : MonoBehaviour
{
    public static bool firstMansionDoorKey = false;
    public bool internalMansionDoorKey;


    [SerializeField] bool firstEye;
    public static bool firstPictureOfEye;

    [SerializeField] bool secondEye;
    public static bool secondPictureOfEye;

    void Update()
    {
        internalMansionDoorKey = firstMansionDoorKey;
        firstEye = firstPictureOfEye;
        secondEye = secondPictureOfEye;
    }
}
