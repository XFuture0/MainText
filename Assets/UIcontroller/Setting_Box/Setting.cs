using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Setting : MonoBehaviour
{
    public GameObject Settings;
    public InputPlayController inputActions;
    [Header("�¼�����")]
    public VoidEventSO SettingsOpenEvent;
    [Header("�㲥")]
    public VoidEventSO Setting_State_Open_Event;
    public VoidEventSO Setting_State_Close_Event;
    private void Awake()
    {
        inputActions = new InputPlayController();
        inputActions.Enable();
        inputActions.UI.Settings.started += OnOut;
    }
    private void OnOut(InputAction.CallbackContext context)
    {
        if (Settings.activeSelf == true)
        {
            Settings.SetActive(false);
            Setting_State_Close_Event.RaiseEvent();
        }
    }
    private void OnEnable()
    {
        SettingsOpenEvent.OnEventRaised += OnOpenSettings;
    }
    private void OnOpenSettings()
    {
        Settings.SetActive(true);
        Setting_State_Open_Event.RaiseEvent();
    }
    private void OnDisable()
    {
        SettingsOpenEvent.OnEventRaised -= OnOpenSettings;
        inputActions.UI.Out.started -= OnOut;
    }
}
