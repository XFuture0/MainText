using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "SceneSO/SceneChangeEventSO")]
public class SceneChangeEventSO : ScriptableObject
{
    public UnityAction<SceneSO,SceneSO, Vector3> OnSceneChangeEvent;
    public void RaiseSceneChangeEvent(SceneSO CurrentScene,SceneSO LocationToGo, Vector3 PositionToGo)
    {
        OnSceneChangeEvent?.Invoke(CurrentScene, LocationToGo, PositionToGo);
    }
}
