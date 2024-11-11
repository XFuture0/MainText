using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Snag : MonoBehaviour
{
    [Header("¹ã²¥")]
    public VoidEventSO DeadEvent;
    private void OnTriggerStay2D(Collider2D collision)
    {
        DeadEvent?.RaiseEvent();
    }
}
