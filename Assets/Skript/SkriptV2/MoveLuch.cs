using UnityEngine;

public class MoveLuch : MonoBehaviour
{
    [SerializeField] private GameObject _go;
    [SerializeField] private Vector3[] _lineTravel;
    [SerializeField] private float _speed;
    [SerializeField] private bool _play;
    private float distance;
    private float distanceContact;
    private bool endPointTravel;
    private int valueNextPoint;
    private Vector3 nextPoint;
    private Vector3 medalPos;

    private void OnEnable()
    {
        ControlSpawnV2.OnStart += OnMove;
        RestartGameV2.NextGame += StartPos;
        RestartGameV2.NextGame += OffMove;
    }

    private void OnDisable()
    {
        ControlSpawnV2.OnStart -= OnMove;
        RestartGameV2.NextGame += StartPos;
        RestartGameV2.NextGame -= OffMove;
    }

    private void Start()
    {
        medalPos = _lineTravel[1];
        distanceContact = 0.5f;
        ChangePoint();
    }

    private void Update()
    {
        if (_play)
        {
            Mover();
        }
    }

    private void Mover()
    {
        ChangeDistance();
        ChangeLine();
        _go.transform.position = Vector3.MoveTowards(transform.position, nextPoint, _speed * Time.deltaTime);
    }

    private void ChangeDistance()
    {
        distance = Vector3.Distance(transform.position, nextPoint);
    }

    private void ChangeLine()
    {
        if (distance < distanceContact)
        {
            ChangePoint();
        }
    }

    private void ChangePoint()
    {
        if (endPointTravel)
        {
            BackPointer();
        }
        else
        {
            ForwardPointer();
        }
    }

    private void ForwardPointer()
    {
        if (valueNextPoint < _lineTravel.Length)
        {
            nextPoint = _lineTravel[valueNextPoint];
            valueNextPoint++;
        }
        else
        {
            End();
        }
    }

    private void BackPointer()
    {
        if (valueNextPoint > 0)
        {
            valueNextPoint--;
            nextPoint = _lineTravel[valueNextPoint];
        }
        else
        {
            End();
        }
    }

    private void End()
    {
        endPointTravel = !endPointTravel;
    }

    private void StartPos()
    {
        _go.transform.position = medalPos;
    }

    private void OffMove()
    {
        _play = false;
    }

    private void OnMove()
    {
        _play = true;
    }
}
