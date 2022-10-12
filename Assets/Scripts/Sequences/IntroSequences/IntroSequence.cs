using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroSequence : MonoBehaviour
{
    [SerializeField] GameObject subtitles;
    [SerializeField] AudioSource line01; // changedMeForever

    [SerializeField] AudioSource line02;

    [SerializeField] AudioSource line03;

    [SerializeField] AudioSource line04;

    [SerializeField] AudioSource line05;

    [SerializeField] AudioSource line06;


    void Start()
    {
        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence()
    {
        yield return new WaitForSeconds(2f);
        line01.Play();
        subtitles.GetComponent<Text>().text = "Цей день змінив мене назавжди...";
        yield return new WaitForSeconds(3.5f);
        subtitles.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(4f);
        line02.Play();
        subtitles.GetComponent<Text>().text = "І я пішов дізнатися,що відбувається там,глибоко в лісі...";
        yield return new WaitForSeconds(4.2f);
        line03.Play();
        subtitles.GetComponent<Text>().text = "І я побачив старий сарай...";
        yield return new WaitForSeconds(3f);
        line04.Play();
        subtitles.GetComponent<Text>().text = "Було дуже вітряно і я вирішив зайти всередину";
        yield return new WaitForSeconds(4f);
        line05.Play();
        subtitles.GetComponent<Text>().text = "Проте звідти доносилися дивні,страшні звуки...";
        yield return new WaitForSeconds(4f);
        subtitles.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(4f);
        line06.Play();
        subtitles.GetComponent<Text>().text = "І я зрозумів,це був тільки початок...";
        yield return new WaitForSeconds(3f);
        subtitles.GetComponent<Text>().text = "";
    }
