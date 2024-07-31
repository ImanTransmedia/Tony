using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Playables;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public PlayableDirector tutorial;

    [SerializeField]
    GameObject menuInicio;

    [SerializeField]
    GameObject monstruo;

    [SerializeField]
    Animator animator;

    [SerializeField]
    Animator animatorTuto;

    [SerializeField]
    GameObject menuFinal;

    [SerializeField]
    int hambre = 0;

    [SerializeField]
    TextMeshProUGUI timeText;

    [SerializeField]
    private float duration = 10f; // Tiempo inicial en segundos

    [SerializeField]
    ScoreManager scoreManager;
    [SerializeField]
    ScoreManager scoreManagerTuto;

    [SerializeField]
    Image finalMessage;

    [SerializeField]
    TextMeshProUGUI score;

    [SerializeField]
    TextMeshProUGUI finalTime;

    [SerializeField]
    Sprite win;

    [SerializeField]
    Sprite lost;

    [SerializeField]
    AudioSource loseAudio;

    [SerializeField]
    AudioSource winAudio;

    [SerializeField]
    GameObject label;

    private bool won;
    private float currentTime; // Tiempo inicial en segundos


    public void StartCountdown()
    {
        monstruo.SetActive(true);
        currentTime = duration;
        scoreManager.Reset();
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        scoreManager.StartCountdown();

        while (currentTime > 0)
        {
            timeText.text = currentTime.ToString("0");
            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        timeText.text = "0";

        won = scoreManager.HasWon();

      

        monstruo.SetActive(false);

        if (won)
        {
            finalMessage.sprite = win;
            monstruo.transform.eulerAngles = new Vector3(0, 0, 0);
            winAudio.Play();
            animator.Play("Monster_Animations|Festejo");
            yield return new WaitForSeconds(2.5f);
        }    
        else
        {
            finalMessage.sprite = lost;
        }

        finalTime.text = currentTime.ToString("0");

        menuFinal.SetActive(true);

        loseAudio.Play();
    }

    IEnumerator MonsterDance()
    {
        monstruo.transform.eulerAngles = new Vector3(0, 0, 0);
        finalTime.text = currentTime.ToString("0");
        winAudio.Play();
        animator.Play("Monster_Animations|Festejo");
        yield return new WaitForSeconds(2.5f);
        monstruo.SetActive(false);
        finalMessage.sprite = win;

        menuFinal.SetActive(true);
    }

    public void EndGame()
    {
        StopAllCoroutines();
        StartCoroutine(MonsterDance());
    }

    public void StartGame()
    {
        scoreManagerTuto.setTutorialState(true, true);
        menuInicio.SetActive(false);
        tutorial.Play();
    }

    public void Reiniciar()
    {
        tutorial.time = 0;
        tutorial.Play();
        menuFinal.SetActive(false);
        label.SetActive(true);
    }
}
