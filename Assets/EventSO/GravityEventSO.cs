using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/GravityEventSO")]
public class GravityEventSO : ScriptableObject
{
    public UnityAction<float,float> OnGravityEventRaised;
    public void GravityEventRaised(float Float1,float Float2)
    {
        OnGravityEventRaised?.Invoke(Float1, Float2);
    }
}
