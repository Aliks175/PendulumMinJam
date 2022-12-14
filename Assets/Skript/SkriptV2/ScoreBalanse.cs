using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBalanse : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField, Range(1, 50)] private int _scoreToCoin = 15;
    [SerializeField, Range(1, 50)] private int _scoreFineToObstacle = 5;
    [SerializeField, Range(1, 50)] private int _scoreFineToNothing = 10;
    [SerializeField] private int _score;
    public static event Action<int> OnScore;

    private void OnEnable()
    {
        RestartGameV2.NextGame += SaveScore;
        ControlSpawnV2.OnStart += ResetScore;
        ActivePush.OnTargetCoin += TargetCoin;
        ActivePush.OnTargetNothing += TargetNothing;
        ActivePush.OnTargetObstacle += TargetObstacle;
    }

    private void OnDisable()
    {
        RestartGameV2.NextGame -= SaveScore;
        ControlSpawnV2.OnStart -= ResetScore;
        ActivePush.OnTargetCoin -= TargetCoin;
        ActivePush.OnTargetNothing -= TargetNothing;
        ActivePush.OnTargetObstacle -= TargetObstacle;
    }

    private void Start()
    {
        ResetScore();
    }

    private void SaveScore()
    {
        OnScore?.Invoke(_score);
    }

    private void ResetScore()
    {
        _score = 0;
        PrintScore();
    }

    private void TargetCoin()
    {
        _score += _scoreToCoin;
        PrintScore();
    }

    private void TargetObstacle()
    {
        MinusScore(_scoreFineToObstacle);
    }

    private void TargetNothing()
    {
        MinusScore(_scoreFineToNothing);
    }

    private void MinusScore(int value)
    {
        if (_score - value < 0)
        {
            _score = 0;
        }
        else
        {
            _score -= value;
        }
        PrintScore();
    }

    private void PrintScore()
    {
        _text.text = _score.ToString();
    }
}
