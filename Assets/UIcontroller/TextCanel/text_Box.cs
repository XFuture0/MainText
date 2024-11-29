using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text_Box : MonoBehaviour
{
    public GameObject Text1z1;
    public GameObject Text1z2z2;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO OpenText1z1Event;
    public VoidEventSO OpenText1z2z2Event;
    private void OnEnable()
    {
        OpenText1z1Event.OnEventRaised += OpenText1z1;
        OpenText1z2z2Event.OnEventRaised += OpenText1z2z2;
    }

    private void OpenText1z2z2()
    {
        Text1z2z2.SetActive(true);
    }

    private void OpenText1z1()
    {
        Text1z1.SetActive(true);
    }

    private void OnDisable()
    {
        OpenText1z1Event.OnEventRaised -= OpenText1z1;
        OpenText1z2z2Event.OnEventRaised -= OpenText1z2z2;
    }
}
