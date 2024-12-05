using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Box : MonoBehaviour
{
    private bool isOpen;
    public GameObject EndBack;
    [Header("¹ã²¥")]
    public VoidEventSO OpenCaremaTrackEvent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOpen)
        {
            if (other.gameObject.tag == "Player")
            {
                EndBack.SetActive(true);
                isOpen = true;
                OpenCaremaTrackEvent.RaiseEvent();
            }
        }
    }
}
