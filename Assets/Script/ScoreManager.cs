using Oculus.Interaction;
using Oculus.Interaction.Samples;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Security.Cryptography;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    TutorialManager tutorialManager;
    [SerializeField]
    TextMeshProUGUI contador;

    [SerializeField]
    GameObject particles;

    public GameManager gameManager;

    private int hambre;
    private int score;

    public bool isPlaying;
    public bool isTutorial;

    // Start is called before the first frame update
    void Start()
    {
        //slider.maxValue = hambre;
        gameManager = FindObjectOfType<GameManager>();

    }

    private void OnTriggerEnter(Collider other)
    {

        //if (isPlaying)
        //{
            particles.SetActive(true);
            score++;
            contador.text = score.ToString();
            other.gameObject.SetActive(false);

            if (isTutorial)
            {
                tutorialManager.SetAcierto(true);
                gameManager.tutorial.Play();
            }
            //if(score == 10)
            //{
            //    gameManager.EndGame();
            //}
        //}
    }

    public bool HasWon()
    {
        isPlaying = false;
        return score == 10 ? true : false;
    }

    public void Reset()
    {
        score = 0;
        contador.text = "0";

    }

    IEnumerator timeToStart()
    {
        yield return new WaitForSeconds(1f);
        isPlaying = true;
    }

    public void StartCountdown()
    {
        StartCoroutine(timeToStart());
    }

    public void SetHambre(int hambre)
    {
        this.hambre = hambre;
    }

    public string GetScore()
    {
        return score.ToString("00");
    }

    public void setTutorialState(bool isTutorial, bool isPlaying)
    {
        this.isTutorial = isTutorial;
        this.isPlaying = true;
    }
}
