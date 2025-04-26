using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthMansion : MonoBehaviour
{
    [SerializeField] int playerHealth = 20;

    void Start()
    {
        
    }

    void Update()
    {
        if(playerHealth <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void DamagePlayer(int damage)
    {
        playerHealth -= damage;
    }
}
