using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/StringEventSO")]
public class StringEventSO : ScriptableObject
{
    public UnityAction<string> OnStringEventRaised;
    public void StringRaiseEvent(string String)
    {
        OnStringEventRaised?.Invoke(String);
    }
}
