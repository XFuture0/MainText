using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class FootStepAudio : MonoBehaviour
{
    private Check check;
    [Header("¹ã²¥")]
    public AudioEventSO FootStepEvent;

    public AudioClip FootStepClip1;
    public AudioClip FootStepClip2;
    public AudioClip FootStepClip3;
    private void Awake()
    {
        check = GetComponent<Check>();
    }
    public void FootStep1()
    {
        if (check.IsGround)
        {
            FootStepEvent.AudioRaiseEvent(FootStepClip1);
        }
    }
    public void FootStep2()
    {
        if (check.IsGround)
        {
            FootStepEvent.AudioRaiseEvent(FootStepClip2);
        }
    }
    public void FootStep3()
    {
        if (check.IsGround)
        {
            FootStepEvent.AudioRaiseEvent(FootStepClip3);
        }
    }
}
