using UnityEngine;

public class GridSpawn : MonoBehaviour
{
    [SerializeField] private bool _isplay;
    [SerializeField, Range(1, 10)] private int _height;
    [SerializeField, Range(1, 10)] private int _length;
    [SerializeField] private GameObject _prefGrid;
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private int _valueBetweenHeight;
    [SerializeField] private int _valueBetweenlength;
    private Vector3 nextPos;

    private void Start()
    {
        nextPos = _startPos;
    }

    private void Update()
    {
        if (_isplay)
        {
            NullGrid();
        }
    }

    private void NullGrid()
    {
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                nextPos.x += _valueBetweenlength;//переменную на длину отступа
                var unit = Instantiate(_prefGrid, nextPos, Quaternion.identity);
            }
            nextPos.x = _startPos.x;
            nextPos.y += _valueBetweenHeight;//переменную на Высоту отступа
        }
        nextPos = _startPos;
        _isplay = false;
    }

    public void RePlay()
    {
        _isplay = true;
    }

    public int CountingSizeGrid()
    {
        int result = _height * _length;
        return result;
    }
}
