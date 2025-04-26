using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] AudioSource buttonHitSfx;
    [SerializeField] GameObject fadeOutScreen;
    public GameObject loadButton;
    public int currentGameSaveIndex = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        currentGameSaveIndex = PlayerPrefs.GetInt("AutoSave");
        if(currentGameSaveIndex > 0)
        {
            loadButton.SetActive(true);
        }
    }

    public void GoToPlaymode()
    {
        StartCoroutine(FadeOutScreen(1));
    }

    public void QuitGame()
    {
        buttonHitSfx.Play();
        Application.Quit();
        print("Quit");
    }

    public void LoadGame()
    {
        StartCoroutine(FadeOutScreen(currentGameSaveIndex));
    }

    IEnumerator FadeOutScreen(int sceneIndex)
    {
        buttonHitSfx.Play();
        fadeOutScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneIndex); 
    }
}
