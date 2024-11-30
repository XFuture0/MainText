using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionBlock_Blue : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite PurpleSprite;
    private int Blue_Count;
    public int Target_Count;
    private bool GetAllBlue;
    private bool OpenAudio;
    public AudioClip Clip;
    [Header("广播")]
    public AudioEventSO GetBlueAudioEvent;
    public VoidEventSO CloseItemAudioEvent;
    [Header("事件监听")]
    public VoidEventSO GetBlueEvent;
    [Header("计时器")]
    public float time;
    private float time_Count;
    private void Awake()
    {
        Blue_Count = 0;
        time_Count = time;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (!GetAllBlue)
        {
            if(Blue_Count == Target_Count)
            {
                GetAllBlue = true;
            }
        }
        if (GetAllBlue)
        {
            if (!OpenAudio)
            {
                OpenAudio = true;
                GetBlueAudioEvent.AudioRaiseEvent(Clip);
            }
            time_Count -= Time.deltaTime;
            if (time_Count > 0)
            {
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - (float)0.05, transform.position.z);
            }
            if(time_Count < 0)
            {
                CloseItemAudioEvent.RaiseEvent();
            }
        }
    }
    private void OnEnable()
    {
        GetBlueEvent.OnEventRaised += OnGetBlue;
    }
    private void OnGetBlue()
    {
        Blue_Count++;
    }
    private void OnDisable()
    {
        GetBlueEvent.OnEventRaised -= OnGetBlue;
    }
}
