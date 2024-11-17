using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class Stop_Box : MonoBehaviour
{
    public InputPlayController inputActions;
    private bool isOpenStop;
    private bool CantOpenStop;
    public GameObject StopMenu;
    public GameObject Setting;
    [Header("¹ã²¥")]
    public VoidEventSO StopPlayerEvent;
    public VoidEventSO ContinuePlayerEvent;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO UnLoadEvent;
    private void Awake()
    {
        inputActions = new InputPlayController();
    }
    private void OnEnable()
    {
        inputActions.UI.Stop.started += StartStop;
        inputActions.Enable();
        UnLoadEvent.OnEventRaised += OnUnLoad;
    }
    private void OnUnLoad()
    {
        Time.timeScale = 1f;
        ContinuePlayerEvent.RaiseEvent();
    }
    private void StartStop(InputAction.CallbackContext context)
    {
        CantOpenStop = GameObject.FindGameObjectWithTag("UIManager");
        if (!CantOpenStop)
        {
            isOpenStop = !isOpenStop;
            StopMenu.SetActive(isOpenStop);
            if (isOpenStop == true)
            {
                Time.timeScale = 0;
                EventSystem.current.SetSelectedGameObject(Setting);
                StopPlayerEvent.RaiseEvent();
            }
            if (isOpenStop == false)
            {
                Time.timeScale = 1f;
                ContinuePlayerEvent.RaiseEvent();
            }
        }
    }
    private void OnDisable()
    {
        UnLoadEvent.OnEventRaised -= OnUnLoad;
    }
}
