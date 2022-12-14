using UnityEngine;

public class PositionCameraV2 : MonoBehaviour
{
    [SerializeField] private GameObject _cameraPlayer;
    [SerializeField] private GameObject _centreField;
    [SerializeField] private float _distance;

    private void OnEnable()
    {
        ControlSpawnV2.OnStart += NextPosCamera;
    }

    private void OnDisable()
    {
        ControlSpawnV2.OnStart += NextPosCamera;
    }

    private void NextPosCamera()
    {
        Vector3 vector = _centreField.transform.position;
        vector.z = _distance;
        _cameraPlayer.transform.position = vector;
    }
}
