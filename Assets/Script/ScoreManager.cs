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
    TextMeshProUGUI finalScore;

    [SerializeField]
    AudioSource audio;

    [SerializeField]
    GameObject particles;

    public GameManager gameManager;

    private int score = 0;

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

        if (isPlaying)
        {
            audio.Play();
            particles.SetActive(true);
            score++;
            contador.text = score.ToString();
            finalScore.text = score.ToString();
            other.gameObject.SetActive(false);

            if (isTutorial)
            {
                tutorialManager.SetAcierto();
            }

            if(score == 10)
            {
                isPlaying = false;
                gameManager.EndGame();
            }
        }
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
        finalScore.text = "0";
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


    public void setTutorialState(bool isTutorial, bool isPlaying)
    {
        this.isTutorial = isTutorial;
        this.isPlaying = true;
    }


}
