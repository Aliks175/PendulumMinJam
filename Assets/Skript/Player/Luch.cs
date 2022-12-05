using UnityEngine;

public class Luch : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private ActivePush _activePush;
    private float distancePos;
    private LineRenderer lineRenderer;
    private Vector3 vector3;
    private RaycastHit hit;

    private void OnEnable()
    {
        InputPlayer.OnPushButton += TargetHit;
    }

    private void OnDisable()
    {
        InputPlayer.OnPushButton -= TargetHit;
    }

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
    }

    void Update()
    {
        transform.LookAt(_target);
        Distance();
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, distancePos))
        {
            vector3 = hit.point;
            lineRenderer.SetPosition(1, vector3);
        }
        else
        {
            lineRenderer.SetPosition(1, _target.position);
        }
    }

    private void Distance()
    {
        distancePos = Vector3.Distance(transform.position, _target.position);
    }

    private void TargetHit()
    {
        _activePush.TransferHit(hit);
    }
}
