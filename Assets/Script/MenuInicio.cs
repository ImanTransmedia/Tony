using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MenuInicio : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Iniciar()
    {
        gameManager.StartGame();
    }

    public void Salir()
    {
        Application.Quit();
    }
    public void Reiniciar()
    {
        gameManager.Reiniciar();
    }
}
