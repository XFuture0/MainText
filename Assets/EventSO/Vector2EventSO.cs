using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/Vector2EventSO")]
public class Vector2EventSO : ScriptableObject
{
    public UnityAction<Vector2> OnVector2EventRaised;
    public void Vector2RaiseEvent(Vector2 vector2)
    {
        OnVector2EventRaised?.Invoke(vector2);
    }
}
