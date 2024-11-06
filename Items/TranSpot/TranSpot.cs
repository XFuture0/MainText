using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TranSpot : MonoBehaviour
{
    public Animator TransformAnim;
    public VoidEventSO TranSpotEvent;
    public GameObject TranSpotLight;
    [Header("¹ã²¥")]
    public AudioEventSO TranSpotAudioEvent;
    public AudioClip TranSpotClip1;
    public AudioClip TranSpotClip2;
    private void Awake()
    {
        TransformAnim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        TranSpotEvent.OnEventRaised += OpenTransform;
    }

    private void OpenTransform()
    {
        TransformAnim.SetTrigger("Open");
    }

    private void OnDisable()
    {
        TranSpotEvent.OnEventRaised -= OpenTransform;
    }
    public void OpenLight()
    {
        TranSpotLight.SetActive(true);
    }
    public void OpenAudio1()
    {
        TranSpotAudioEvent?.AudioRaiseEvent(TranSpotClip1);
    }
    public void OpenAudio2()
    {
        TranSpotAudioEvent?.AudioRaiseEvent(TranSpotClip2);
    }
}
