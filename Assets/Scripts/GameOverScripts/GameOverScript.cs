using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] int mainMenuIndex = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(mainMenuIndex);
    }

    public void LoadGame()
    {
        int previousSceneIndex = PlayerPrefs.GetInt("AutoSave");
        SceneManager.LoadScene(previousSceneIndex);
    }
}
