using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3ing : MonoBehaviour
{
    public AudioEventSO Attack3Event;
    public AudioClip Attack3Clip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 10)
        {
            Attack3Event.AudioRaiseEvent(Attack3Clip);
        }
    }
}
