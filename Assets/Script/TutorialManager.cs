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
    GameObject gameMonstar;

    bool acierto = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FirstMessage()
    {
        if (acierto)
        {
            mensajeFallo1.SetActive(false);
        }
        Debug.Log("1");
        playableDirector.Play();
        acierto = false;
    }
    public void SecondMessage()
    {
        if (acierto)
        {
            mensajeFallo2.SetActive(false);
        }
        Debug.Log("2");
        playableDirector.Play();

    }
    public void StartGame()
    {
        
    }
    public void SetAcierto(bool acierto)
    {
        this.acierto = acierto;
        playableDirector.Play();
    }
}
