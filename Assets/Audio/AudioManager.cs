using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    [Header("事件监听")]
    public AudioEventSO SavePointAudio;
    public AudioEventSO FootStepAudio;
    public AudioEventSO FXEventSO;
    public AudioEventSO TranSpotAudioEvent;
    public FlaotEventSO AudioChangeEvent;
    [Header("音乐管理器")]
    public AudioSource SavePointsourse;
    public AudioSource FootStepsourse;
    public AudioSource FXsourse;
    public AudioSource BGMsourse;
    [Header("音量调节器")]
    public AudioMixer MainMixer;
    private void OnEnable()
    {
        SavePointAudio.OnAudioEventRaised += SavePointing;
        FootStepAudio.OnAudioEventRaised += FootStep;
        FXEventSO.OnAudioEventRaised += FXAudio;
        TranSpotAudioEvent.OnAudioEventRaised += BGMAudio;
        AudioChangeEvent.OnFloatEventRaised += OnAudioChange;
    }

    private void OnAudioChange(float ChangeAudio)
    {
        ChangeAudio = ChangeAudio * 100 - 80;
        MainMixer.SetFloat("MasterAudio", ChangeAudio);
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
        AudioChangeEvent.OnFloatEventRaised -= OnAudioChange;
    }
}
