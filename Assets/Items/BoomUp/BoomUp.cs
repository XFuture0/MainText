using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;

public class BoomUp : MonoBehaviour
{
    public GravityEventSO BoomHigh;
    public float BoomHighing;
    public float Boom_Time;
    private bool isboom;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isboom)
        {
            BoomHigh.GravityEventRaised(BoomHighing, Boom_Time);
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
