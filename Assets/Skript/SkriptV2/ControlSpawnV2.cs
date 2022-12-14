using System;
using UnityEngine;

public class ControlSpawnV2 : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private int _valueCoins;
    [SerializeField, Range(1, 10)] private int _valueObstacle;
    [SerializeField] private GameObject _coinPref;
    [SerializeField] private GameObject _obstaclePref;
    [SerializeField] private SpawnGridV2 _spawnGridV2;
    private bool iscoin;
    public static event Action OnEndSpawnObstacle;
    public static event Action OnStart;
    public static event Action<int> OnSpawnValueCoins;

    private void Spawn(GameObject go, int value, bool iscoins)
    {
        for (int i = 0; i < value; i++)
        {
            _spawnGridV2.NullGrid(go, iscoins);
        }
    }

    private void ComandSpawnGameElements()
    {
        iscoin = true;
        Spawn(_coinPref, _valueCoins, iscoin);
        iscoin = false;
        Spawn(_obstaclePref, _valueObstacle, iscoin);
        OnEndSpawnObstacle?.Invoke();
        OnSpawnValueCoins?.Invoke(_valueCoins);
    }

    public void Play()
    {
        ComandSpawnGameElements();
        OnStart?.Invoke();
    }
}
