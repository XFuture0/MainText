using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/GameObjectEventSO")]
public class GameObjectEventSO : ScriptableObject
{
    public UnityAction<GameObject> OnGameObjectEventRaised;
    public void GameObjectRaiseEvent(GameObject gameObject)
    {
        OnGameObjectEventRaised?.Invoke(gameObject);
    }
}
