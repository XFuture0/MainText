using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageBoss : MonoBehaviour
{
    public GameObject CloseBlock;
    public Transform DeathTr;
    public Transform Player;
    public Vector3 RestartState;
    private bool isOpen;
    [Header("¹ã²¥")]
    public VoidEventSO StopPlayerEvent;
    public VoidEventSO ContinuePlayerEvent;
    public TransformEventSO TrackDeathEvent;
    public TransformEventSO ChangeRestartEvent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOpen)
        {
            Player.position = RestartState;
            isOpen = true;
            CloseBlock.SetActive(true);
            ChangeRestartEvent.TransformRaiseEvent(Player);
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
