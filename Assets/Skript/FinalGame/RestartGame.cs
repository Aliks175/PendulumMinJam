using System;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameObject _miniGame;
    private GameObject[] coinsArray;
    private GameObject[] obstacleArray;
    public static event Action NextGame;

    public void StartNextGame()
    {
        NextGame?.Invoke();
    }

    private void OnEnable()
    {
        WinGame.OnWin += StopGame;
        GameOver.OnGameOver += StopGame;
        NextGame += OnOffGame;
    }

    private void OnDisable()
    {
        WinGame.OnWin -= StopGame;
        GameOver.OnGameOver -= StopGame;
        NextGame -= OnOffGame;
    }

    private void OnOffGame()
    {
        _miniGame.SetActive(!_miniGame.activeSelf);
    }

    private void StopGame()
    {
        DestroyGame();
    }

    private void DestroyGame()
    {
        coinsArray = GameObject.FindGameObjectsWithTag(ConstValue.TagCoins);
        ClearGame(coinsArray);
        obstacleArray = GameObject.FindGameObjectsWithTag(ConstValue.TagObstacle);
        ClearGame(obstacleArray);
    }

    private void ClearGame(GameObject[] goArray)
    {
        foreach (var item in goArray)
        {
            if (item == null)
            {
                continue;
            }
            else
            {
                Destroy(item.gameObject);
            }
        }
    }
}
