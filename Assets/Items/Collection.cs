using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite CloseSprite;
    public GameObject Light;
    public Collider2D StopCollider;
    public AudioClip GetClip;
    public AudioClip Get_EndClip;
    private bool IsGetCollec;
    [Header("¹ã²¥")]
    public VoidEventSO StopPlayerEvent;
    public VoidEventSO ContinuePlayerEvent;
    public AudioEventSO GetCollectEvent;
    public AudioEventSO Get_EndCollectEvent;
    public VoidEventSO CollectionAddEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsGetCollec)
        {
            IsGetCollec = true;
            StopPlayerEvent.RaiseEvent();
            GetCollectEvent.AudioRaiseEvent(GetClip);
            StopCollider.enabled = false;
            StartCoroutine(Time_Stop());
        }
    }
    private IEnumerator Time_Stop()
    {
        yield return new WaitForSeconds(1f);
        ContinuePlayerEvent.RaiseEvent();
        Light.gameObject.SetActive(false);
        Get_EndCollectEvent.AudioRaiseEvent(Get_EndClip);
        spriteRenderer.sprite = CloseSprite;
        yield return new WaitForSeconds(0.2f);
        CollectionAddEvent.RaiseEvent();
    }
}
