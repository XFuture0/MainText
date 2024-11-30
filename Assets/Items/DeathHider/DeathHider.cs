using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHider : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    private bool OpenText;
    [Header("�㲥")]
    public VoidEventSO OpenText1z2z9Event;
    public VoidEventSO StopPlayerEvent;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
