using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraImpulse : MonoBehaviour
{
    public CinemachineImpulseSource DashImpulsing;
    [Header("¹ã²¥")]
    public VoidEventSO CaremaImpulseEvent;
    private void OnEnable()
    {
        CaremaImpulseEvent.OnEventRaised += Impulsing;
    }

    private void Impulsing()
    {
        DashImpulsing.GenerateImpulse();
    }

    private void OnDisable()
    {
        CaremaImpulseEvent.OnEventRaised -= Impulsing;
    }
}
