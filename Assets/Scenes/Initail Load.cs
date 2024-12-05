using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class InitailLoad : MonoBehaviour
{
    public AssetReference InitalScene;
    private void Awake()
    {
        Addressables.LoadSceneAsync(InitalScene);
    }
}
