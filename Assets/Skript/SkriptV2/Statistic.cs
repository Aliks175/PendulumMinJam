using UnityEngine;
using UnityEngine.UI;

public class Statistic : MonoBehaviour
{
    [SerializeField] private Text _textField;
    private int time;
    private int valueScore;
    private int valueCoinsLost;

    private void OnEnable()
    {
        RestartGameV2.NextGame += PrintTest;
        ScoreBalanse.OnScore += PrintScore;
        WinGameV2.OnValueCoin += PrintValueCoins;
        TimeGame.OnTime += PrintTime;
    }

    private void OnDisable()
    {
        RestartGameV2.NextGame -= PrintTest;
        ScoreBalanse.OnScore -= PrintScore;
        WinGameV2.OnValueCoin -= PrintValueCoins;
        TimeGame.OnTime -= PrintTime;
    }

    private void PrintTest()
    {
        _textField.text = $"{time}\n{valueCoinsLost}\n{valueScore}";
    }

    private void PrintTime(int f)
    {
        time = f;
        PrintTest();
    }

    private void PrintScore(int value)
    {
        valueScore = value;
        PrintTest();
    }

    private void PrintValueCoins(int i)
    {
        valueCoinsLost = i;
        PrintTest();
    }
}
