using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SceneChangePoint : MonoBehaviour
{
    public SceneSO CurrentScene;
    public SceneSO SceneToGo;
    public Vector3 PositionToGo;
    private bool isChange;
    [Header("¹ã²¥")]
    public SceneChangeEventSO ChangeEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isChange)
        {
            isChange = true;
            ChangeEvent.RaiseSceneChangeEvent(CurrentScene, SceneToGo, PositionToGo);
        }
    }
}
