using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranSpotController : MonoBehaviour
{
    public VoidEventSO TranSpotOpenEvent;
    public void OpenTransform()
    {
        TranSpotOpenEvent?.RaiseEvent();
    }
}
