using System.Collections.Generic;
using UnityEngine;

public class SpawnGridV2 : MonoBehaviour
{
    [SerializeField] private int _height;
    [SerializeField] private int _length;
    [SerializeField] private GameObject _centreLuch;
    [SerializeField] private GameObject _startPointField;
    [SerializeField] private ClearingLineV2 _clearingLineV2;
    [SerializeField] private Vector3 _sizeNullZone = new(7f, 3f, 3f);
    private Vector3 spawnPos;
    private bool checkSpawn;
    private float x, y, z;
    private int checkOverStack;
    private BoxCollider pointFieldColl;
    private Collider[] arrayColliders;
    private GameObject nextGo;
    private List<GameObject> gameElement;
    private const int maxValueRePlay = 20;

    private void OnEnable()
    {
        RestartGameV2.NextGame += DestroyGo;
    }

    private void OnDisable()
    {
        RestartGameV2.NextGame -= DestroyGo;
    }

    private void Awake()
    {
        gameElement = new List<GameObject>();
        pointFieldColl = _startPointField.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        Vector3 vector = new(_length, _height, 1);
        pointFieldColl.size = vector;
    }

    private void DestroyGo()
    {
        foreach (var item in gameElement)
        {
            Destroy(item.gameObject);
        }
    }

    public void NullGrid(GameObject go, bool iscoin)
    {
        x = Random.Range(pointFieldColl.transform.position.x - Random.Range(0, pointFieldColl.bounds.extents.x), pointFieldColl.transform.position.x + Random.Range(0, pointFieldColl.bounds.extents.x));
        y = Random.Range(pointFieldColl.transform.position.y - Random.Range(0, pointFieldColl.bounds.extents.y), pointFieldColl.transform.position.y + Random.Range(0, pointFieldColl.bounds.extents.y));
        z = pointFieldColl.transform.position.z - 10f;
        spawnPos = new Vector3(x, y, z);
        checkSpawn = CheckSpawnPoint(spawnPos);
        if (checkSpawn)
        {
            checkOverStack = 0;
            nextGo = Instantiate(go, spawnPos, Quaternion.identity);
            gameElement.Add(nextGo);
            if (iscoin)
            {
                _clearingLineV2.FindTarget(nextGo.transform);
            }
        }
        else if (checkOverStack > maxValueRePlay)
        {

        }
        else
        {
            checkOverStack++;
            NullGrid(go, iscoin);
        }
    }

    private bool CheckSpawnPoint(Vector3 vector3)
    {
        arrayColliders = Physics.OverlapBox(vector3, _sizeNullZone);
        if (arrayColliders.Length > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
