using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ControlSpawn : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private int _valueCoins;
    [SerializeField, Range(1, 10)] private int _valueObstacle;
    [SerializeField] private GridSpawn _gridSpawn;
    private GameObject[] arrayGo;
    private int lengthArrayGo;
    private bool isendSpawnCoins;
    public static event Action OnEndSpawnCoins;
    public static event Action<GameObject> OnSpawnToScene;

    public static void GoOnSpawn(GameObject go)
    {
        OnSpawnToScene?.Invoke(go);
    }

    private void OnEnable()
    {
        RestartGame.NextGame += OnCoinsEndSpawn;
        OnSpawnToScene += SaveArrayGo;
    }

    private void OnDisable()
    {
        RestartGame.NextGame -= OnCoinsEndSpawn;
        OnSpawnToScene -= SaveArrayGo;
    }

    void Start()
    {
        lengthArrayGo = _gridSpawn.CountingSizeGrid();
        arrayGo = new GameObject[lengthArrayGo];
    }

    private void SaveArrayGo(GameObject go)
    {
        for (int i = 0; i < arrayGo.Length; i++)
        {
            if (arrayGo[i] == null)
            {
                arrayGo[i] = go;
                if (i == arrayGo.Length - 1)
                {
                    SpawnField();
                }
                break;
            }
            else
            {
                continue;
            }
        }
    }

    private void SpawnField()
    {
        RandomValueArray(_valueCoins);
        OnCoinsEndSpawn();
        RandomValueArray(_valueObstacle);
        ClearingGrid();
        OnEndSpawnCoins?.Invoke();
    }

    private void RandomValueArray(int value)
    {
        for (int i = 0; i < value;)
        {
            int runV = Random.Range(0, arrayGo.Length);
            if (arrayGo[runV] == null)
            {
                continue;
            }
            else
            {
                if (isendSpawnCoins)
                {
                    SpawnObstacle(arrayGo[runV]);
                }
                else
                {
                    SpawnCoins(arrayGo[runV]);
                }
                arrayGo[runV] = null;
                i++;
            }
        }
    }

    private void OnCoinsEndSpawn()
    {
        isendSpawnCoins = !isendSpawnCoins;
    }

    private void ClearingGrid()
    {
        foreach (var item in arrayGo)
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

    private void SpawnCoins(GameObject gp)
    {
        var gf = gp.GetComponent<CoinsSpawn>();
        gf.OnSpawn();
    }

    private void SpawnObstacle(GameObject gp)
    {
        var gf = gp.GetComponent<SpawnObstacle>();
        gf.OnSpawn();
    }
}
