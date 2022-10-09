using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 20;
    [SerializeField] GameObject hurtPlayerFlash;


    void Update()
    {
        if(playerHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            print("The playes has popped his clogs");
        }
    }

    public void DamagePlayer(int damage) // Special for Animation event
    {
        StartCoroutine(PlayerHurtFlash());
        playerHealth -= damage;
        print("test");
    }

    IEnumerator PlayerHurtFlash()
    {
        hurtPlayerFlash.SetActive(true);
        yield return new WaitForSeconds(0.09f);
        hurtPlayerFlash.SetActive(false);
    }
}
