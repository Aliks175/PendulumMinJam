using System.Collections.Generic;
using UnityEngine;

public class ClearingLineV2 : MonoBehaviour
{
    [SerializeField] private GameObject _nullPointPref;
    [SerializeField] private Transform _secondGo;
    private const float step = 1.5f;
    private Vector3 line;
    private Vector3 nextPos;
    private Transform targetGo;
    private GameObject point;
    private List<GameObject> pointsLine;

    private void OnEnable()
    {
        ControlSpawnV2.OnEndSpawnObstacle += DestroyPointsLine;
    }

    private void OnDisable()
    {
        ControlSpawnV2.OnEndSpawnObstacle -= DestroyPointsLine;
    }

    private void Start()
    {
        pointsLine = new List<GameObject>();
    }

    private void DestroyPointsLine()
    {
        foreach (var item in pointsLine)
        {
            Destroy(item.gameObject);
        }
    }

    public void FindTarget(Transform transform)
    {
        targetGo = transform;
        nextPos = targetGo.position;
        line = _secondGo.position - targetGo.position;
        PrintLine();
    }

    private bool CheckDistance()
    {
        bool isfinalPos;
        float distance;
        distance = Vector3.Distance(nextPos, _secondGo.position);
        if (distance < step)
        {
            isfinalPos = false;
        }
        else
        {
            isfinalPos = true;
        }
        return isfinalPos;
    }

    private void PrintLine()
    {
        while (CheckDistance())
        {
            point = Instantiate(_nullPointPref, nextPos, Quaternion.identity);
            pointsLine.Add(point);
            nextPos += line.normalized * step;
        }
    }
}
