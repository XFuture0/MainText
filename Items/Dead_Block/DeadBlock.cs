using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBlock : MonoBehaviour
{
    public VoidEventSO DeadEvent;
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DeadEvent?.RaiseEvent();
        }
    }
}
