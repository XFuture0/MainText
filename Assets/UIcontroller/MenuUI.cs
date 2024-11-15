using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenuUI : MonoBehaviour
{
    public GameObject X_Key;
    public GameObject Exit_Key;
    public GameObject MainMenu;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO ReturnEvent;
    public VoidEventSO X_In_Event;
    private void OnEnable()
    {
        ReturnEvent.OnEventRaised += OnReturn;
        X_In_Event.OnEventRaised += On_X_In;
    }

    private void On_X_In()
    {
        MainMenu.SetActive(true);
    }

    private void OnReturn()
    {
        X_Key.SetActive(true);
        Exit_Key.SetActive(true);
    }
    private void OnDisable()
    {
        ReturnEvent.OnEventRaised -= OnReturn;
        X_In_Event.OnEventRaised -= On_X_In;
    }
}
