using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emoji_worry : MonoBehaviour
{
    public GameObject Own;
    public Collider2D StopCollider;
    public AudioClip GetClip;
    private bool IsGetEmoji;
    [Header("¹ã²¥")]
    public VoidEventSO StopPlayerEvent;
    public VoidEventSO ContinuePlayerEvent;
    public AudioEventSO GetCollectEvent;
    public VoidEventSO GetEmoji_worryEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsGetEmoji)
        {
            IsGetEmoji = true;
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
        Own.gameObject.SetActive(false);
        GetEmoji_worryEvent.RaiseEvent();
    }
}
