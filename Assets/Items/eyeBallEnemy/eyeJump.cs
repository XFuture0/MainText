using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeJump : MonoBehaviour
{
    [Header("�㲥")]
    public VoidEventSO eyeJumpEvent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            eyeJumpEvent.RaiseEvent();
        }
    }
}
