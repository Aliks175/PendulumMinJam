using System;
using UnityEngine;

[RequireComponent(typeof(LuchV2))]
public class ActivePush : MonoBehaviour
{
    private RaycastHit raycastHit;
    public static event Action OnTargetCoin;
    public static event Action OnTargetObstacle;
    public static event Action OnTargetNothing;

    public void TransferHit(RaycastHit hit)
    {
        raycastHit = hit;
        CheckTarget();
    }

    private void CheckTarget()
    {
        if (raycastHit.collider == null)
        {
            OnTargetNothing?.Invoke();
        }
        else
        {
            switch (raycastHit.transform.tag)
            {
                case ConstValue.TagCoins:
                    OnTargetCoin?.Invoke();
                    Destroy(raycastHit.collider.gameObject);
                    break;
                case ConstValue.TagObstacle:
                    OnTargetObstacle?.Invoke();
                    break;
            }
        }
    }
}
