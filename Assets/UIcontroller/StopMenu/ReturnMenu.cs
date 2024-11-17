using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using UnityEngine.EventSystems;
public class ReturnMenu : MonoBehaviour
{
    private string Name;
    public Button ReturnMenuing;
    public InputPlayController inputActions;
    public GameObject Energy_Line;
    [Header("¹ã²¥")]
    public VoidEventSO ReturnMainMenuEvent;
    private void Awake()
    {
        inputActions = new InputPlayController();
    }
    private void OnEnable()
    {
        inputActions.UI.In.started += OnReturnMenu;
        inputActions.Enable();
    }

    private void OnReturnMenu(InputAction.CallbackContext context)
    {
        Name = EventSystem.current.currentSelectedGameObject.name;
        if (Name == "ReturnMenu")
        {
            ReturnMenuing?.onClick.Invoke();
        }
    }
    public void ReturnMenued()
    {
        Energy_Line.SetActive(false);
        ReturnMainMenuEvent.RaiseEvent();
    }
    private void OnDisable()
    {
        inputActions.UI.In.started -= OnReturnMenu;
    }
}
