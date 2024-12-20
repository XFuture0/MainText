using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class UIcontroller : MonoBehaviour
{
    public InputPlayController inputActions;
    private bool canPressZ;
    private bool canPressX;
    [Header("�㲥")]
    public VoidEventSO Press_X_Event;
    public VoidEventSO Press_Z_Event;
    [Header("�¼�����")]
    public VoidEventSO Setting_State_Open_Event;
    public VoidEventSO Setting_State_Close_Event;
    private void Awake()
    {
        inputActions = new InputPlayController();
        inputActions.UI.In.started += OnIn;
        inputActions.UI.Out.started += OnOut;
        inputActions.Enable();
        canPressZ = true;
        canPressX = true;
    }
    private void OnIn(InputAction.CallbackContext context)
    {
        if (canPressX)
        {
            Press_X_Event.RaiseEvent();
        }
    }
    private void OnOut(InputAction.CallbackContext context)
    {
        if (canPressZ)
        {
            Press_Z_Event.RaiseEvent();
        }
    }
    private void OnEnable()
    {
        Setting_State_Open_Event.OnEventRaised += OnSetting_Open_State;
        Setting_State_Close_Event.OnEventRaised += OnSetting_Close_State;
    }

    private void OnSetting_Close_State()
    {
        canPressZ = true;
        canPressX = true;
    }
    private void OnSetting_Open_State()
    {
        canPressZ = false;
        canPressX = false;
    }
    private void OnDisable()
    {
        Setting_State_Open_Event.OnEventRaised -= OnSetting_Open_State;
        Setting_State_Close_Event.OnEventRaised -= OnSetting_Close_State;
    }
}
