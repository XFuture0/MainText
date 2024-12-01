using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOpen : MonoBehaviour
{
    [Header("¹ã²¥")]
    public VoidEventSO OpenText1z1Event;
    public VoidEventSO CloseBGMEvent;
    private bool isOpen;
    private void OnEnable()
    {
        CloseBGMEvent.RaiseEvent();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOpen)
        {
            isOpen = true;
            OpenText1z1Event.RaiseEvent();
        }
    }
}
