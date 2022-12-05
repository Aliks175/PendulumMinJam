using System;
using UnityEngine;

[RequireComponent(typeof(Luch))]
public class ActivePush : MonoBehaviour
{
    private RaycastHit _raycastHit;
    public static event Action OnTargetCoin;
    public static event Action OnTargetObstacle;
    public static event Action OnTargetNothing;
    public static event Action OnPlay;

    public void TransferHit(RaycastHit hit)
    {
        _raycastHit = hit;
        CheckTarget();
    }

    private void CheckTarget()
    {
        if (_raycastHit.collider == null)
        {
            Debug.Log("-30 Nothing");
            OnTargetNothing?.Invoke();
        }
        else
        {
            switch (_raycastHit.transform.tag)
            {
                case ConstValue.TagCoins:
                    Debug.Log("+ 15 Coins");
                    OnTargetCoin?.Invoke();
                    Destroy(_raycastHit.collider.gameObject);
                    break;
                case ConstValue.TagObstacle:
                    Debug.Log("-15 Trap");
                    OnTargetObstacle?.Invoke();
                    Destroy(_raycastHit.collider.gameObject);
                    break;
            }
        }
        OnPlay?.Invoke();//запуск движения вновь
    }
}
