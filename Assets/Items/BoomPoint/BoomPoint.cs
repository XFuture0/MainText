using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomPoint : MonoBehaviour
{
    public GravityEventSO BoomSpeed;
    public float BoomSpeeding;
    public float Boom_Time;
    private bool isboom;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isboom)
        {
            BoomSpeed.GravityEventRaised(BoomSpeeding,Boom_Time);
            isboom = true;
            StartCoroutine(WaitTime());
        }
    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5f);
        isboom = false;
    }
}
