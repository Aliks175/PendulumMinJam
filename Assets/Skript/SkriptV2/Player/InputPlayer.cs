using System;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public static event Action OnPushButton;

    void Update()
    {
        if (Input.GetMouseButtonDown(ConstValue.PushMouse))
        {
            OnPushButton?.Invoke();
        }
    }
}
