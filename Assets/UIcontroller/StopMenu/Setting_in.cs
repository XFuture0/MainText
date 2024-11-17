using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using UnityEngine.EventSystems;
public class Setting_in : MonoBehaviour
{
    private string Name;
    public Button Settingin;
    public InputPlayController inputActions;
    public GameObject Setting;
    private void Awake()
    {
        inputActions = new InputPlayController();
    }
    private void OnEnable()
    {
        inputActions.UI.In.started += OnOpenSetting;
        inputActions.Enable();
    }

    private void OnOpenSetting(InputAction.CallbackContext context)
    {
        Name = EventSystem.current.currentSelectedGameObject.name;
        if (Name == "Setting_in")
        {
            Settingin?.onClick.Invoke();
        }
    }
    public void OpenSet()
    {
        Setting.SetActive(true);
    }
    private void OnDisable()
    {
        inputActions.UI.In.started -= OnOpenSetting;
    }
}
