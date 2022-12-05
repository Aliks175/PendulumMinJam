using System;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    private GameObject[] arrayCoins;
    private bool isnullArray;
    public static event Action OnWin;

    private void OnEnable()
    {
        ControlSpawn.OnEndSpawnCoins += SerchArrayCoins;
        InputPlayer.OnPushButton += CheckWin;
    }

    private void OnDisable()
    {
        ControlSpawn.OnEndSpawnCoins -= SerchArrayCoins;
        InputPlayer.OnPushButton -= CheckWin;
    }

    private void SerchArrayCoins()
    {
        arrayCoins = GameObject.FindGameObjectsWithTag(ConstValue.TagCoins);
    }

    private void CheckWin()
    {
        for (int i = 0; i < arrayCoins.Length; i++)
        {
            if (arrayCoins[i] == null)
            {
                isnullArray = true;
                continue;
            }
            else
            {
                isnullArray = false;
                break;
            }
        }
        Win();
    }

    private void Win()
    {
        if (isnullArray)
        {
            OnWin?.Invoke();
            _winPanel.SetActive(true);
        }
    }
}
