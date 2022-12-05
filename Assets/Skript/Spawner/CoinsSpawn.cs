using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _coinPref;
    [SerializeField] private bool _isplay;

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
        Instantiate(_coinPref, transform.position, Quaternion.Euler(transform.rotation.eulerAngles));
        Destroy(gameObject);
    }

    public void OnSpawn()
    {
        _isplay = true;
    }
}
