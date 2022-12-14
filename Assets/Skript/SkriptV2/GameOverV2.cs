using System;
using UnityEngine;

public class GameOverV2 : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    public static event Action OnGameOver;

    public static void EndTime()
    {
        OnGameOver?.Invoke();
    }

    private void OnEnable()
    {
        OnGameOver += End;
    }

    private void OnDisable()
    {
        OnGameOver -= End;
    }

    private void End()
    {
        _gameOverPanel.SetActive(true);
    }
}
