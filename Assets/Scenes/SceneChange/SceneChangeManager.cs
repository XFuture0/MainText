using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
public class SceneChangeManager : MonoBehaviour
{
    public GameObject MainPlayer;
    private string currentscene;
    private SceneSO ChangeScene;
    private Vector3 ChangePosition;
    [Header("ÊÂ¼þ¼àÌý")]
    public SceneChangeEventSO ChangeEvent;
    [Header("¹ã²¥")]
    public VoidEventSO BoundChangeEvent;
    private void OnEnable()
    {
        ChangeEvent.OnSceneChangeEvent += OnChangeScene;
    }

    private void OnChangeScene(SceneSO CurrentScene, SceneSO SceneToGo, Vector3 PositionToGo)
    {
        ChangeScene = SceneToGo;
        ChangePosition = PositionToGo;
        currentscene = CurrentScene.SceneName;
        StartCoroutine(CloseScene());
    }
    private IEnumerator CloseScene()
    {
        SceneManager.UnloadSceneAsync(currentscene);
        MainPlayer.transform.position = ChangePosition;
        yield return ChangeScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
        BoundChangeEvent.RaiseEvent();
    }
    private void OnDisable()
    {
        ChangeEvent.OnSceneChangeEvent -= OnChangeScene;
    }
}
