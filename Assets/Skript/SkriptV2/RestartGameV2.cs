using System;
using UnityEngine;

public class RestartGameV2 : MonoBehaviour
{
    public static event Action NextGame;

    public void StartNextGame()
    {
        NextGame?.Invoke();
    }

    private void OnEnable()
    {
        WinGameV2.OnWin += StartNextGame;
        GameOverV2.OnGameOver += StartNextGame;
    }

    private void OnDisable()
    {
        WinGameV2.OnWin -= StartNextGame;
        GameOverV2.OnGameOver -= StartNextGame;
    }
}
