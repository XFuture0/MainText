using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/GravityEventSO")]
public class GravityEventSO : ScriptableObject
{
    public UnityAction<float,float,float,float> OnGravityEventRaised;
    public void GravityEventRaised(float Float1,float Float2,float Float3,float Float4)
    {
        OnGravityEventRaised?.Invoke(Float1, Float2, Float3,Float4);
    }
}
