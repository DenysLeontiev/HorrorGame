using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour
{
    [SerializeField] GameObject ammoText;

    static int ammoCount;
    [SerializeField] int ammoCountToShowInInspector;
    public static int AmmoCount
    {
        get
        {
            return ammoCount;
        }
        set
        {
            ammoCount = value;
        }
    }

    void Update()
    {
        ammoCountToShowInInspector = ammoCount;
        if(ammoText != null)
            ammoText.GetComponent<Text>().text = ammoCount.ToString();
    }

    public static void Shoot()
    {
        ammoCount--;
    }

    public static void PickUpAmmo(int value)
    {
        ammoCount = value;
    }
}
