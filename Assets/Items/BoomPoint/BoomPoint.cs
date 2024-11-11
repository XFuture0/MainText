using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomPoint : MonoBehaviour
{
    public FlaotEventSO BoomSpeed;
    public FlaotEventSO BoomHigh;
    public float BoomSpeeding;
    public float BoomHighing;
    private bool isboom;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isboom)
        {
            BoomSpeed.FloatRaiseEvent(BoomSpeeding);
            BoomHigh.FloatRaiseEvent(BoomHighing);
            isboom = true;
        }
    }
}
