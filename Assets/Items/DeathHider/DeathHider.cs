using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHider : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    private bool OpenText;
    public AudioClip BGMClip;
    [Header("¹ã²¥")]
    public VoidEventSO OpenText1z2z9Event;
    public VoidEventSO StopPlayerEvent;
    public AudioEventSO OpenBGMEvent;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        OpenBGMEvent.AudioRaiseEvent(BGMClip);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!OpenText)
        {
            OpenText = true;
            StopPlayerEvent.RaiseEvent();
            OpenText1z2z9Event.RaiseEvent();
            spriteRenderer.sprite = sprite;
        }
    }
}
