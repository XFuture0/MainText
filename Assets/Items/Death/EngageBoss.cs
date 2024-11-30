using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageBoss : MonoBehaviour
{
    public Transform DeathTr;
    private bool isOpen;
    [Header("¹ã²¥")]
    public VoidEventSO StopPlayerEvent;
    public VoidEventSO ContinuePlayerEvent;
    public TransformEventSO TrackDeathEvent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOpen)
        {
            isOpen = true;
            if (other.tag == "Player")
            {
                DeathTr.gameObject.SetActive(true);
                TrackDeathEvent.TransformRaiseEvent(DeathTr);
                StopPlayerEvent.RaiseEvent();
                StartCoroutine(WaitTime());
            }
        }
    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(3f);
        ContinuePlayerEvent.RaiseEvent();
    }
}
