using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] AudioSource buttonHitSfx;
    [SerializeField] GameObject fadeOutScreen;

    public void GoToPlaymode()
    {
        buttonHitSfx.Play();
        StartCoroutine(FadeOutScreen());
    }

    public void QuitGame()
    {
        buttonHitSfx.Play();
        Application.Quit();
        print("Quit");
    }

    IEnumerator FadeOutScreen()
    {
        fadeOutScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}
