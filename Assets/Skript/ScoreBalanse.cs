using UnityEngine;
using UnityEngine.UI;

public class ScoreBalanse : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField, Range(1, 50)] private int _scoreToCoin = 15;
    [SerializeField, Range(1, 50)] private int _scoreFineToObstacle = 5;
    [SerializeField, Range(1, 50)] private int _scoreFineToNothing = 10;
    [SerializeField] private int score;

    private void OnEnable()
    {
        RestartGame.NextGame += ResetScore;
        ActivePush.OnTargetCoin += TargetCoin;
        ActivePush.OnTargetNothing += TargetNothing;
        ActivePush.OnTargetObstacle += TargetObstacle;
    }

    private void OnDisable()
    {
        RestartGame.NextGame -= ResetScore;
        ActivePush.OnTargetCoin -= TargetCoin;
        ActivePush.OnTargetNothing -= TargetNothing;
        ActivePush.OnTargetObstacle -= TargetObstacle;
    }

    private void Start()
    {
        ResetScore();
    }

    private void ResetScore()
    {
        score = 0;
        PrintScore();
    }

    private void TargetCoin()
    {
        score += _scoreToCoin;
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
        if (score - value < 0)
        {
            score = 0;
        }
        else
        {
            score -= value;
        }
        PrintScore();
    }

    private void PrintScore()
    {
        _text.text = score.ToString();
    }
}
