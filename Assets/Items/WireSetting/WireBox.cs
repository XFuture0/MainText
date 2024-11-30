using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class WireBox : MonoBehaviour
{
    private bool isRush;
    public AudioClip Clip;
    [Header("¹ã²¥")]
    public AudioEventSO DestoryWireAudioEvent;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO EyeEnemyRushEvent;
    public VoidEventSO EyeEnemyNoRushEvent;
    private void OnEnable()
    {
        EyeEnemyRushEvent.OnEventRaised += OnRush;
        EyeEnemyNoRushEvent.OnEventRaised += OnNoRush;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "EyeBall" && isRush == true)
        {
            DestoryWireAudioEvent.AudioRaiseEvent(Clip);
            Destroy(this.gameObject);
        }
    }
    private void OnNoRush()
    {
        isRush = false;
    }
    private void OnRush()
    {
        isRush = true;
    }
    private void OnDisable()
    {
        EyeEnemyRushEvent.OnEventRaised -= OnRush;
        EyeEnemyNoRushEvent.OnEventRaised -= OnNoRush;
    }
}
