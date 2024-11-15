using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class UIcontroller : MonoBehaviour
{
    public InputPlayController inputActions;
    [Header("¹ã²¥")]
    public VoidEventSO Press_X_Event;
    public VoidEventSO Press_Z_Event;
    private void Awake()
    {
        inputActions = new InputPlayController();
        inputActions.UI.In.started += OnIn;
        inputActions.UI.Out.started += OnOut;
        inputActions.Enable();
    }
    private void OnIn(InputAction.CallbackContext context)
    {
        Press_X_Event.RaiseEvent();
    }
    private void OnOut(InputAction.CallbackContext context)
    {
        Press_Z_Event.RaiseEvent();
    }
}
