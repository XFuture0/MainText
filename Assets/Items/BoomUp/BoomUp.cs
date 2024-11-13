using System.Collections;
using System.Collections.Generic;
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
        }
    }
}
