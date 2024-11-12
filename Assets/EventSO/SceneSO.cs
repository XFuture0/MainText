using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
[CreateAssetMenu(menuName = "SceneSO/GameSceneSO")]
public class SceneSO : ScriptableObject
{
    public string SceneName;
    public SceneType Scenetype;
    public AssetReference sceneReference;
}
