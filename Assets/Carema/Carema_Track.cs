using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Carema_Track : MonoBehaviour
{
    private Transform Carema_Position;
    private Vector3 Last_Position;
    public Transform Back1;
    public Transform Back2;
    private bool IsOpenTrack;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO OpenCaremaTrackEvent;
    private void Start()
    {
        Carema_Position = transform;
        Last_Position = transform.position;
    }
    private void Update()
    {
        if (IsOpenTrack)
        {
            Carema_Position = transform;
            var Amount_Move = Carema_Position.position - Last_Position;
            Back2.transform.position += new Vector3((float)(Amount_Move.x * 0.5), (float)(Amount_Move.y * 0.05), 0);
            Back1.transform.position += new Vector3((float)(Amount_Move.x * 0.8), (float)(Amount_Move.y * 0.1), 0);
            Last_Position = transform.position;
        }
    }
    private void OnEnable()
    {
        OpenCaremaTrackEvent.OnEventRaised += OnOpenCaremaTrack;
    }

    private void OnOpenCaremaTrack()
    {
        IsOpenTrack = true;
    }
    private void OnDisable()
    {
        OpenCaremaTrackEvent.OnEventRaised -= OnOpenCaremaTrack;
    }
}
