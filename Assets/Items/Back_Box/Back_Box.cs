using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Box : MonoBehaviour
{
    private bool isOpen;
    [Header("�㲥")]
    public VoidEventSO OpenCaremaTrackEvent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOpen)
        {
            if (other.gameObject.tag == "Player")
            {
                isOpen = true;
                OpenCaremaTrackEvent.RaiseEvent();
            }
        }
    }
}
