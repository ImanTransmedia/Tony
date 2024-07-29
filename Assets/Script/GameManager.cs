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
    GameObject menuFinal;

    [SerializeField]
    int hambre = 0;

    [SerializeField]
    TextMeshProUGUI timeText;

    [SerializeField]
    private float duration = 5f; // Tiempo inicial en segundos

    [SerializeField]
    ScoreManager scoreManager;
    [SerializeField]
    ScoreManager scoreManagerTuto;

    [SerializeField]
    Image finalMessage;

    [SerializeField]
    TextMeshProUGUI score;

    [SerializeField]
    Sprite win;

    [SerializeField]
    Sprite lost;

    private bool won;
    private float currentTime; // Tiempo inicial en segundos

    // Start is called before the first frame update
    void Start()
    {
        //scoreManager.SetHambre(hambre);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCountdown()
    {
        monstruo.SetActive(true);
        currentTime = duration;
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
            finalMessage.sprite = win;
        else
            finalMessage.sprite = lost;

        menuFinal.SetActive(true);

        score.text = scoreManager.GetScore();
    }

    public void EndGame()
    {
        StopAllCoroutines();
        monstruo.SetActive(false);
        finalMessage.sprite = win;
        menuFinal.SetActive(true);
    }

    public void StartGame()
    {
        scoreManagerTuto.setTutorialState(true, true);
        menuInicio.SetActive(false);
        tutorial.Play();
        //currentTime = duration;
        //monstruo.SetActive(true);
        //scoreManager.Reset();
        //StartCountdown();
    }
    public void Reiniciar()
    {
        tutorial.time = 0;
        tutorial.Play();
        menuFinal.SetActive(false);
    }
}
