using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class Start_text : MonoBehaviour
{
    public SceneSO currentscene;
    public SceneSO ChangeScene;
    public Vector3 ChangePosition;
    private bool canPressX;
    private string Name;
    public Button Start;
    public InputPlayController inputActions;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO Setting_State_Open_Event;
    public VoidEventSO Setting_State_Close_Event;
    [Header("¹ã²¥")]
    public SceneChangeEventSO NewGameEvent;
    private void Awake()
    {
        inputActions = new InputPlayController();
        canPressX = true;
    }
    private void OnEnable()
    {
        inputActions.UI.In.started += OnStart;
        inputActions.Enable();
        Setting_State_Open_Event.OnEventRaised += OnSetting_Open_State;
        Setting_State_Close_Event.OnEventRaised += OnSetting_Close_State;
    }

    private void OnSetting_Close_State()
    {
        canPressX = true;
    }

    private void OnSetting_Open_State()
    {
        canPressX = false;
    }
    private void OnStart(InputAction.CallbackContext context)
    {
        Name = EventSystem.current.currentSelectedGameObject.name;
        if (Name == "Start_text")
        {
            if (canPressX)
            {
                Start?.onClick.Invoke();
            }
        }
    }
    private void OnDisable()
    {
        inputActions.UI.In.started -= OnStart;
        Setting_State_Open_Event.OnEventRaised -= OnSetting_Open_State;
        Setting_State_Close_Event.OnEventRaised -= OnSetting_Close_State;
    }
    public void StartGame()
    {
        NewGameEvent.RaiseSceneChangeEvent(currentscene,ChangeScene,ChangePosition);
        SceneManager.UnloadSceneAsync(currentscene.SceneName);
    }
}
