using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Carema_Track : MonoBehaviour
{
    private Transform Player;
    private Transform Carema_Position;
    private Transform Last_Position;
   // public Vector3 Amount_Move;
    private bool FirstTime;
    public Transform Back;
    public Transform Back1;
    public Transform Back2;
    [Header("ÊÂ¼þ¼àÌý")]
    public TransformEventSO PlayerPositionEvent;
    private void Awake()
    {
        FirstTime = true;
    }
    private void OnEnable()
    {
        PlayerPositionEvent.OnTransformEventRaised += OnCarema_Position;
    }

    private void OnCarema_Position(Transform Carema_Position)
    {
        if (FirstTime)
        {
           FirstTime=false;
            Last_Position = Carema_Position;
        }
        if (!FirstTime)
        {
            var Amount_Move = Carema_Position.position - Last_Position.position;
            Back2.transform.position += new Vector3((float)(Amount_Move.x * 0.5), (float)(Amount_Move.y * 0.5), 0);
        }
        Last_Position = Carema_Position;
    }

    private void OnDisable()
    {
        PlayerPositionEvent.OnTransformEventRaised -= OnCarema_Position;
    }
}
