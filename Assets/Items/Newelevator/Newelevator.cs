using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newelevator : MonoBehaviour
{
    public Transform own;
    public GameObject X_Key;
    public GameObject Exit_Key;
    public GameObject FirstSelect;
    [Header("�¼�����")]
    public VoidEventSO Press_X_Event;
    [Header("�㲥")]
    public TransformEventSO Press_X_TransformEvent;
    public GameObjectEventSO FirstSelectEvent;
    private void OnEnable()
    {
        Press_X_Event.OnEventRaised += On_Press_X;
    }
    private void On_Press_X()
    {
        X_Key.SetActive(false);
        Exit_Key.SetActive(false);
        FirstSelectEvent.GameObjectRaiseEvent(FirstSelect);
        Press_X_TransformEvent.TransformRaiseEvent(own);
    }
    private void OnDisable()
    {
        Press_X_Event.OnEventRaised -= On_Press_X;
    }
}
