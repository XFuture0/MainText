using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOpen : MonoBehaviour
{
    [Header("�㲥")]
    public VoidEventSO OpenText1z1Event;    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OpenText1z1Event.RaiseEvent();
    }
}
