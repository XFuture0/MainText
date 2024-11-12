using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomPoint : MonoBehaviour
{
    public GravityEventSO BoomSpeed;
    public float BoomSpeeding;
    public float BoomHighing;
    public float Boom_Gravity;
    public float Boom_Time;
    private bool isboom;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isboom)
        {
            BoomSpeed.GravityEventRaised(BoomSpeeding,BoomHighing,Boom_Gravity,Boom_Time);
            isboom = true;
        }
    }
}
