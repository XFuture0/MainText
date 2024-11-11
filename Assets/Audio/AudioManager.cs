using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    [Header("ÊÂ¼þ¼àÌý")]
    public AudioEventSO SavePointAudio;
    public AudioEventSO FootStepAudio;
    public AudioEventSO FXEventSO;
    public AudioEventSO TranSpotAudioEvent;

    public AudioSource SavePointsourse;
    public AudioSource FootStepsourse;
    public AudioSource FXsourse;
    public AudioSource BGMsourse;
    private void OnEnable()
    {
        SavePointAudio.OnAudioEventRaised += SavePointing;
        FootStepAudio.OnAudioEventRaised += FootStep;
        FXEventSO.OnAudioEventRaised += FXAudio;
        TranSpotAudioEvent.OnAudioEventRaised += BGMAudio;
    }

    private void BGMAudio(AudioClip Clip)
    {
        BGMsourse.clip = Clip;
        BGMsourse.Play();
    }

    private void FXAudio(AudioClip Clip)
    {
        FXsourse.clip = Clip;
        FXsourse.Play();
    }

    private void FootStep(AudioClip Clip)
    {
        FootStepsourse.clip = Clip;
        FootStepsourse.Play();
    }

    private void SavePointing(AudioClip Clip)
    {
        SavePointsourse.clip = Clip;
        SavePointsourse.Play();
    }

    private void OnDisable()
    {
        SavePointAudio.OnAudioEventRaised -= SavePointing;
        FootStepAudio.OnAudioEventRaised -= FootStep;
        FXEventSO.OnAudioEventRaised -= FXAudio;
        TranSpotAudioEvent.OnAudioEventRaised -= BGMAudio;
    }
}
