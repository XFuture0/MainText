using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newtree : MonoBehaviour
{
    public Transform own;
    public GameObject MainMenu;
    [Header("�¼�����")]
    public VoidEventSO Press_Z_Event;
    [Header("�㲥")]
    public TransformEventSO Press_Z_TransformEvent;
    private void OnEnable()
    {
        Press_Z_Event.OnEventRaised += On_Press_Z;
    }
    private void On_Press_Z()
    {
        MainMenu.SetActive(false);
        Press_Z_TransformEvent.TransformRaiseEvent(own);
    }
    private void OnDisable()
    {
        Press_Z_Event.OnEventRaised -= On_Press_Z;
    }
}
