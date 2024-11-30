using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection_Blue : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite PurpleSprite;
    private bool isGetBlue;
    public AudioClip Clip;
    [Header("¹ã²¥")]
    public VoidEventSO GetBlueEvent;
    public AudioEventSO GetBlueAudioEvent;
    private void Awake()
    {
        isGetBlue = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isGetBlue && other.tag == "Player")
        {
            isGetBlue = false;
            GetBlueAudioEvent.AudioRaiseEvent(Clip);
            spriteRenderer.sprite = PurpleSprite;
            GetBlueEvent.RaiseEvent();
        }
    }
}
