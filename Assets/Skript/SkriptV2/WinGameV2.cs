using System;
using UnityEngine;

public class WinGameV2 : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    private int valueCoins;
    public static event Action OnWin;
    public static event Action<int> OnValueCoin;

    private void OnEnable()
    {
        RestartGameV2.NextGame += TranslateValueCoins;
        ControlSpawnV2.OnSpawnValueCoins += Coin;
        ActivePush.OnTargetCoin += CheckWin;
    }

    private void OnDisable()
    {
        RestartGameV2.NextGame -= TranslateValueCoins;
        ControlSpawnV2.OnSpawnValueCoins -= Coin;
        ActivePush.OnTargetCoin -= CheckWin;
    }
    private void TranslateValueCoins()
    {
        OnValueCoin?.Invoke(valueCoins);
    }
    private void Coin(int value)
    {
        valueCoins = value;
    }

    private void CheckWin()
    {
        valueCoins--;
        if (valueCoins <= 0)
        {
            Win();
        }
    }

    private void Win()
    {
        OnWin?.Invoke();
        _winPanel.SetActive(true);
    }
}
