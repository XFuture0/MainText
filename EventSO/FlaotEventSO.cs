using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/FloatEventSO")]
public class FlaotEventSO : ScriptableObject
{
    public UnityAction<float> OnFloatEventRaised;
    public void FloatRaiseEvent(float Float)
    {
        OnFloatEventRaised?.Invoke(Float);
    }
}
