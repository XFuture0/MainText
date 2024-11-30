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
    public AudioEventSO BGMEvent;
    public AudioEventSO BGMFEvent;
    public FlaotEventSO AudioChangeEvent;
    public AudioEventSO ItemAudioEvent;
    public VoidEventSO CloseBGMEvent;
    public VoidEventSO CloseItemEvent;
    [Header("音乐管理器")]
    public AudioSource SavePointsourse;
    public AudioSource FootStepsourse;
    public AudioSource FXsourse;
    public AudioSource BGMsourse;
    public AudioSource BGMFsourse;
    public AudioSource Itemsourse;
    [Header("音量调节器")]
    public AudioMixer MainMixer;
    private void OnEnable()
    {
        SavePointAudio.OnAudioEventRaised += SavePointing;
        FootStepAudio.OnAudioEventRaised += FootStep;
        FXEventSO.OnAudioEventRaised += FXAudio;
        TranSpotAudioEvent.OnAudioEventRaised += BGMAudio;
        AudioChangeEvent.OnFloatEventRaised += OnAudioChange;
        BGMEvent.OnAudioEventRaised += OnBGMAudio;
        BGMFEvent.OnAudioEventRaised += OnBGMFAudio;
        ItemAudioEvent.OnAudioEventRaised += OnItemAudio;
        CloseBGMEvent.OnEventRaised += OnCloseBGM;
        CloseItemEvent.OnEventRaised += OnCloseItem;
    }
    private void OnCloseItem()
    {
        Itemsourse.Stop();
    }

    private void OnCloseBGM()
    {
        BGMsourse.Stop();
    }

    private void OnItemAudio(AudioClip Clip)
    {
        Itemsourse.clip = Clip;
        Itemsourse.Play();
    }
    private void OnBGMFAudio(AudioClip Clip)
    {
        BGMFsourse.clip = Clip;
        BGMFsourse.Play();
    }

    private void OnBGMAudio(AudioClip Clip)
    {
        BGMsourse.clip = Clip;
        BGMsourse.Play();
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
        BGMEvent.OnAudioEventRaised -= OnBGMAudio;
        BGMFEvent.OnAudioEventRaised -= OnBGMFAudio;
        ItemAudioEvent.OnAudioEventRaised -= OnItemAudio;
        CloseBGMEvent.OnEventRaised -= OnCloseBGM;
        CloseItemEvent.OnEventRaised -= OnCloseItem;
    }
}
