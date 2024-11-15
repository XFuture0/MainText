using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/TransformEventSO")]
public class TransformEventSO : ScriptableObject
{
    public UnityAction<Transform> OnTransformEventRaised;
    public void TransformRaiseEvent(Transform transform)
    {
        OnTransformEventRaised?.Invoke(transform);
    }
}
