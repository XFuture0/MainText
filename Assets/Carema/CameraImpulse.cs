using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraImpulse : MonoBehaviour
{
    [Header("¹ã²¥")]
    public VoidEventSO CaremaImpulseEvent;
    public CinemachineImpulseSource DashImpulsing;
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
