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
    public GameObject own;
    public GameObject MainCarema;
    public GameObject StopMenu;
    public GameObject empty;
    public GameObject Energy_Line;
    public SceneSO FirstScene;
    private SceneSO currentscene;
    private SceneSO ChangeScene;
    private Vector3 ChangePosition;
    private bool isNewGame;
    private bool isEndGame;
    [Header("主场景")]
    public SceneSO Noscene;
    public SceneSO MenuScene;
    public Vector3 MenuPosition;
    [Header("事件监听")]
    public SceneChangeEventSO ChangeEvent;
    public SceneChangeEventSO NewGameEvent;
    public VoidEventSO SceneRestartEvent;
    public VoidEventSO ReturnMainMenuEvent;
    public TransformEventSO ChangeRestartEvent;
    [Header("广播")]
    public VoidEventSO BoundChangeEvent;
    public VoidEventSO DeadRestart;
    public VoidEventSO FadeinEvent;
    public VoidEventSO LookPlayerEvent;
    public VoidEventSO UnLoadEvent;
    public VoidEventSO StopPlayerEvent;
    public VoidEventSO ContinuePlayerEvent;
    private void Start()
    {
        FirstScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
    }
    private void OnEnable()
    {
        ChangeEvent.OnSceneChangeEvent += OnChangeScene;
        SceneRestartEvent.OnEventRaised += OnSceneRestart;
        NewGameEvent.OnSceneChangeEvent += OnNewGame;
        ReturnMainMenuEvent.OnEventRaised += OnMainMenu;
        ChangeRestartEvent.OnTransformEventRaised += OnChangeRestart;
    }

    private void OnChangeRestart(Transform Player)
    {
        ChangePosition = Player.position;
    }

    private void OnMainMenu()
    {
        isEndGame = true;
        StopMenu.SetActive(false);
        FadeinEvent.RaiseEvent();
        UnLoadEvent.RaiseEvent();
        StartCoroutine(LoadMainMenu());
    }
    private IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(5f);
        OnChangeScene(Noscene, MenuScene, MenuPosition);
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
        Energy_Line.SetActive(true);
        MainPlayer.SetActive(true);
        StopPlayerEvent.RaiseEvent();
        LookPlayerEvent.RaiseEvent();
        OnChangeScene(currentscene,ChangeScene,ChangePosition);
        yield return new WaitForSeconds(2f);
        ContinuePlayerEvent.RaiseEvent();
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
        if (!isNewGame && !isEndGame)
        {
            yield return SceneManager.UnloadSceneAsync(currentscene.SceneName);
        }
        if (!isEndGame)
        {
            MainPlayer.transform.position = ChangePosition;
        }
        yield return ChangeScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
        BoundChangeEvent.RaiseEvent();
        isNewGame = false;
        isEndGame = false;
    }
    private void OnDisable()
    {
        ChangeEvent.OnSceneChangeEvent -= OnChangeScene;
        SceneRestartEvent.OnEventRaised -= OnSceneRestart;
        NewGameEvent.OnSceneChangeEvent -= OnNewGame;
        ReturnMainMenuEvent.OnEventRaised -= OnMainMenu;
        ChangeRestartEvent.OnTransformEventRaised -= OnChangeRestart;
    }
}
