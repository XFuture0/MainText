using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBox1z2z9 : MonoBehaviour
{
    public GameObject End_Text;
    public GameObject End_Canvs;
    [Header("¹ã²¥")]
    public VoidEventSO StopPlayerEvent;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO OpenEndCanvsEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopPlayerEvent.RaiseEvent();
        End_Text.SetActive(true);
    }
    private void OnEnable()
    {
        OpenEndCanvsEvent.OnEventRaised += OnOpenEndCanvs;
    }

    private void OnOpenEndCanvs()
    {
        End_Canvs.SetActive(true);
    }

    private void OnDisable()
    {
        OpenEndCanvsEvent.OnEventRaised -= OnOpenEndCanvs;
    }
}
