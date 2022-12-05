using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] _arrayGo;
    [SerializeField] private bool _isplay;
    [SerializeField] private int _indexGo;
    private int value;
    private const int StepArray = 1;

    private void Start()
    {
        ControlSpawn.GoOnSpawn(gameObject);
    }

    private void Update()
    {
        if (_isplay)
        {
            Spawn();
            _isplay = false;
        }
    }

    private void Spawn()
    {
        RunGo();
        Instantiate(_arrayGo[value], transform.position, Quaternion.Euler(transform.rotation.eulerAngles));
        Destroy(gameObject);
    }

    private void RunGo()
    {
        value = Random.Range(0, _arrayGo.Length - StepArray);
    }

    public void OnSpawn()
    {
        _isplay = true;
    }
}
