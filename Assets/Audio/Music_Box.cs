using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Box : MonoBehaviour
{
    public AudioClip BGM1;
    public AudioClip BGMF1;
    [Header("¹ã²¥")]
    public AudioEventSO BGMEvent;
    public AudioEventSO BGMFEvent;
    private void Start()
    {
        BGMEvent.AudioRaiseEvent(BGM1);
        BGMFEvent.AudioRaiseEvent(BGMF1);
    }
}
