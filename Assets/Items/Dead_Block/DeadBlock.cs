using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBlock : MonoBehaviour
{
    [Header("¹ã²¥")]
    public VoidEventSO DeadEvent;
    public VoidEventSO NoDeadEvent;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!(gameObject.tag == "CanDestory"))
            {
                DeadEvent?.RaiseEvent();
            }
            if(gameObject.tag == "CanDestory")
            {
                NoDeadEvent?.RaiseEvent();
            }
        }
    }
}
