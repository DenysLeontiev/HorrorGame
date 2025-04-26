using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int playerHealth = 20;
    [SerializeField] GameObject hurtPlayerFlash;
    [SerializeField] GameObject fpsController;

    [SerializeField] int levelIndexToLoad = 0;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            print("Saved");
            SavePlayer();
        }
        else if(Input.GetKeyDown(KeyCode.O))
        {
            print("Loaded");
            LoadPlayer();
        }

        if(playerHealth <= 0)
        {
            SceneManager.LoadScene(levelIndexToLoad);
            print("The playes has popped his clogs");
        }

        print(playerHealth);
    }

    public void DamagePlayer(int damage) // Special for Animation event
    {
        // StartCoroutine(PlayerHurtFlash());
        playerHealth -= damage;
    }

    IEnumerator PlayerHurtFlash()
    {
        // hurtPlayerFlash.SetActive(true); // red screen while hit
        yield return new WaitForSeconds(0.09f);
        // hurtPlayerFlash.SetActive(false);
    }

    public void SavePlayer()
    {
        SaveSystem.Save(this);
    }

    public void LoadPlayer()
    {
        PlayerDataToSave playerDataToSave = SaveSystem.Load();
        playerHealth = playerDataToSave.health;
        Vector3 savedPlayerPos = new Vector3(playerDataToSave.playerPosition[0], playerDataToSave.playerPosition[1], playerDataToSave.playerPosition[2]);
        this.GetComponent<Transform>().position = savedPlayerPos;
    }
}
