using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    PlayableDirector playableDirector;

    [SerializeField]
    GameObject mensajeAcierto1;
    [SerializeField]
    GameObject mensajeAcierto2;
    [SerializeField]
    GameObject mensajeFallo1;
    [SerializeField]
    GameObject mensajeFallo2;
    [SerializeField]
    GameObject gameMonster;

    private int successes = 0;
    private int attempts = 1;
    private bool hasWinned = false;
    private bool tutorialEnded = true;

    public void ActivateMessage()
    {
        if (!tutorialEnded)
        {
            FirstMessage();

            attempts++;
        }
    }

    public void FirstMessage()
    {
        gameMonster.SetActive(false);

        if (successes > 0 && hasWinned)
        {
             mensajeAcierto2.SetActive(true);

            StartCoroutine(ItsHungry());
        }
        else if(attempts == 3 )
        {
            tutorialEnded = true;
            HideMessage();
            playableDirector.Play();
        }
        else
        {
            if (successes > 0)
            {
                mensajeAcierto1.SetActive(true);
                hasWinned = true;
            }
            else if (successes == 0 && attempts > 1)
            {
                mensajeFallo2.SetActive(true);
            }
            else if(successes == 0 && attempts == 1)
            {
                mensajeFallo1.SetActive(true);
            }
           
             
           
            StartCoroutine(ItsAlive());
            successes = 0;

        }
    }


    public void SetAcierto()
    {
        successes++;
    }

    public void StartTutorial()
    {
        playableDirector.Pause();
        tutorialEnded = false;
        hasWinned = false;
        successes = 0;
        attempts = 1;
        gameMonster.SetActive(true);
    }
    public void HideMessage()
    {
        mensajeAcierto1.SetActive(false);
        mensajeAcierto2.SetActive(false);
        mensajeFallo1.SetActive(false);
        mensajeFallo2.SetActive(false);

    }

    IEnumerator ItsAlive()
    {
        tutorialEnded = true;
        yield return new WaitForSeconds(4f);
        HideMessage();
        gameMonster.SetActive(true);
        tutorialEnded = false;
    }

    IEnumerator ItsHungry()
    {
        tutorialEnded = true;
        yield return new WaitForSeconds(4f);
        HideMessage();
        playableDirector.Play();
    }
}
