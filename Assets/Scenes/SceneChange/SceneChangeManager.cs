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
    private SceneSO currentscene;
    private SceneSO ChangeScene;
    private Vector3 ChangePosition;
    private bool isNewGame;
    [Header("ÊÂ¼þ¼àÌý")]
    public SceneChangeEventSO ChangeEvent;
    public SceneChangeEventSO NewGameEvent;
    public VoidEventSO SceneRestartEvent;
    [Header("¹ã²¥")]
    public VoidEventSO BoundChangeEvent;
    public VoidEventSO DeadRestart;
    public VoidEventSO FadeinEvent;
    public VoidEventSO LookPlayerEvent;
    private void OnEnable()
    {
        ChangeEvent.OnSceneChangeEvent += OnChangeScene;
        SceneRestartEvent.OnEventRaised += OnSceneRestart;
        NewGameEvent.OnSceneChangeEvent += OnNewGame;
    }

    private void OnNewGame(SceneSO CurrentScene, SceneSO SceneToGo, Vector3 PositionToGo)
    {
        ChangeScene = SceneToGo;
        ChangePosition = PositionToGo;
        currentscene = CurrentScene;
        isNewGame = true;
        FadeinEvent.RaiseEvent();
        StartCoroutine(NewGameFade());
    }
    private IEnumerator NewGameFade()
    {
        yield return new WaitForSeconds(2f);
        MainPlayer.SetActive(true);
        LookPlayerEvent.RaiseEvent();
        OnChangeScene(currentscene,ChangeScene,ChangePosition);
    }
    private void OnSceneRestart()
    {
        currentscene = ChangeScene;
        StartCoroutine(CloseScene());
        DeadRestart.RaiseEvent();  
    }
    private void OnChangeScene(SceneSO CurrentScene, SceneSO SceneToGo, Vector3 PositionToGo)
    {
        ChangeScene = SceneToGo;
        ChangePosition = PositionToGo;
        currentscene = CurrentScene;
        StartCoroutine(CloseScene());
    }
    private IEnumerator CloseScene()
    {
        if (!isNewGame)
        {
            yield return SceneManager.UnloadSceneAsync(currentscene.SceneName);
        }
        MainPlayer.transform.position = ChangePosition;
        yield return ChangeScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
        BoundChangeEvent.RaiseEvent();
        isNewGame = false;
    }
    private void OnDisable()
    {
        ChangeEvent.OnSceneChangeEvent -= OnChangeScene;
        SceneRestartEvent.OnEventRaised -= OnSceneRestart;
        NewGameEvent.OnSceneChangeEvent -= OnNewGame;
    }
}
