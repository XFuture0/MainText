using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBlock : MonoBehaviour
{
    public bool isHitsth;
    public AudioClip DeadClip;
    [Header("¹ã²¥")]
    public VoidEventSO DeadEvent;
    public VoidEventSO NoDeadEvent;
    public AudioEventSO DeadAudioEvent;
    private void Awake()
    {
        isHitsth = true;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isHitsth)
        {
            if (!(gameObject.tag == "CanDestory"))
            {
                DeadAudioEvent.AudioRaiseEvent(DeadClip);
                DeadEvent?.RaiseEvent();
            }
            if(gameObject.tag == "CanDestory")
            {
                NoDeadEvent?.RaiseEvent();
                isHitsth = false;
            }
            StartCoroutine(WaitTime());
        }
    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5f);
        isHitsth = true;
    }
}
