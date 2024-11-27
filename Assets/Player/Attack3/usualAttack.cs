using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usualAttack : MonoBehaviour
{
    public AudioEventSO Attack3Event;
    public AudioClip Attack3Clip;
    private void OnEnable()
    {
        Attack3Event.AudioRaiseEvent(Attack3Clip);
    }
}
