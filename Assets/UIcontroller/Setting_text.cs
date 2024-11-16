using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
public class Setting_text : MonoBehaviour
{
    public Button Setting;
    private string Name;
    public InputPlayController inputActions;
    [Header("¹ã²¥")]
    public VoidEventSO SettingsOpenEvent;
    private void Awake()
    {
        inputActions = new InputPlayController();
    }
    private void OnEnable()
    {
        inputActions.UI.In.started += OnSetting;
        inputActions.Enable();
    }
    private void OnSetting(InputAction.CallbackContext context)
    {
        Name = EventSystem.current.currentSelectedGameObject.name;
        if (Name == "Setting_text")
        {
            Setting?.onClick.Invoke();
        }
    }

    private void OnDisable()
    {
        inputActions.UI.In.started -= OnSetting;
    }
    public void GameSetting()
    {
        SettingsOpenEvent.RaiseEvent();
    }
}
