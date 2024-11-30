using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;
public class CaremaChange : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;
    public Transform Current_Tranform;
    public Transform Current_Tranform_temp;
    public Transform Player;
    public Transform own;
    public float SizeChange_X;
    public float SizeChange_Z;
    public bool isPressX;
    public bool isPressZ;
    private GameObject FirseSelecting;
    public GameObject SettingSelecting;
    private bool isUnLoad;
    [Header("ÊÂ¼þ¼àÌý")]
    public TransformEventSO Press_X_TransformEvent;
    public TransformEventSO Press_Z_TransformEvent;
    public TransformEventSO TrackDeathEvent;
    public GameObjectEventSO FirstSelectEvent;
    public VoidEventSO Setting_State_Close_Event;
    public VoidEventSO LookPlayerEvent;
    public VoidEventSO UnLoadEvent;
    public VoidEventSO CloseTargetEvent;
    [Header("¹ã²¥")]
    public VoidEventSO ReturnEvent;
    public VoidEventSO X_In_Event;
    public VoidEventSO Set_State_Open_Event;
    public VoidEventSO Set_State_Close_Event;
    public TransformEventSO PlayerPositionEvent;
    private void Awake()
    {
        Current_Tranform.name = "Newtree";
    }
    private void Update()
    {
        PlayerPositionEvent.TransformRaiseEvent(own);
    }
    private void FixedUpdate()
    {
        if (isPressX)
        {
            VirtualCamera.m_Lens.OrthographicSize = VirtualCamera.m_Lens.OrthographicSize * SizeChange_X;
            if (VirtualCamera.m_Lens.OrthographicSize <= 0.32)
            {
                isPressX = false;
            }
        }
        if (isPressZ)
        {
            VirtualCamera.m_Lens.OrthographicSize = VirtualCamera.m_Lens.OrthographicSize * SizeChange_Z;
            if (VirtualCamera.m_Lens.OrthographicSize >= 2.1)
            {
                isPressZ = false;
                ReturnEvent.RaiseEvent();
            }
        }
    }
    private void OnEnable()
    {
        Press_X_TransformEvent.OnTransformEventRaised += OnPress_X_TransformEvent;
        Press_Z_TransformEvent.OnTransformEventRaised += OnPress_Z_TransformEvent;
        FirstSelectEvent.OnGameObjectEventRaised += OnFirstSelect;
        Setting_State_Close_Event.OnEventRaised += OnSetting_Close_State;
        LookPlayerEvent.OnEventRaised += OnLookPlayer;
        UnLoadEvent.OnEventRaised += OnUnLoad;
        CloseTargetEvent.OnEventRaised += OnCloseTarget;
        TrackDeathEvent.OnTransformEventRaised += OnTrackDeath;
    }

    private void OnTrackDeath(Transform DeathTransform)
    {
        VirtualCamera.Follow = DeathTransform;
        VirtualCamera.LookAt = DeathTransform;
    }

    private void OnCloseTarget()
    {
        Current_Tranform = Current_Tranform_temp;
    }

    private void OnUnLoad()
    {
        isUnLoad = true;
        EventSystem.current.SetSelectedGameObject(null);
        VirtualCamera.Follow = null;
        VirtualCamera.LookAt = null;
        VirtualCamera.transform.position = new Vector3((float)-65.2,(float)4.3, -10);
        VirtualCamera.m_Lens.OrthographicSize = 2.54f;
    }

    private void OnLookPlayer()
    {
        VirtualCamera.Follow = Player;
        VirtualCamera.LookAt = Player;
        VirtualCamera.m_Lens.OrthographicSize = 5.42f;
    }

    private void OnSetting_Close_State()
    {
       var SelectFirst = GameObject.FindGameObjectWithTag("UIManager");
        if (SelectFirst)
        {
            EventSystem.current.SetSelectedGameObject(FirseSelecting);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(SettingSelecting);
        }
    }

    private void OnFirstSelect(GameObject firstselect)
    {
        FirseSelecting = firstselect;
    }

    private void OnPress_Z_TransformEvent(Transform target)
    {
        if (target.name != Current_Tranform.name)
        {
            Current_Tranform = target;
            isPressZ = true;
            StartCoroutine(Transform_Z_Position());
        }
        else
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }

    private void OnPress_X_TransformEvent(Transform target)
    {
        if (isUnLoad)
        {
            Current_Tranform.name = "NewTree";
        }
        if (target.name != Current_Tranform.name)
        {
            Set_State_Open_Event.RaiseEvent();
            isUnLoad = false;
            Current_Tranform = target;
            VirtualCamera.Follow = Current_Tranform;
            VirtualCamera.LookAt = Current_Tranform;
            StartCoroutine(Transform_X_Position());
        }
        
    }
    private IEnumerator Transform_X_Position()
    {
        yield return new WaitForSeconds(0.5f);
        isPressX = true;
        yield return new WaitForSeconds(0.5f);
        X_In_Event.RaiseEvent();
        EventSystem.current.SetSelectedGameObject(FirseSelecting);
        yield return new WaitForSeconds(0.5f);
        Set_State_Close_Event.RaiseEvent();
    }
    private IEnumerator Transform_Z_Position()
    {
        Set_State_Open_Event.RaiseEvent();
        yield return new WaitForSeconds(0.5f);
        VirtualCamera.Follow = Current_Tranform;
        VirtualCamera.LookAt = Current_Tranform;
        yield return new WaitForSeconds(1f);
        Set_State_Close_Event.RaiseEvent();
    }
    private void OnDisable()
    {
        Press_X_TransformEvent.OnTransformEventRaised -= OnPress_X_TransformEvent;
        Press_Z_TransformEvent.OnTransformEventRaised -= OnPress_Z_TransformEvent;
        FirstSelectEvent.OnGameObjectEventRaised -= OnFirstSelect;
        Setting_State_Close_Event.OnEventRaised += OnSetting_Close_State;
        LookPlayerEvent.OnEventRaised -= OnLookPlayer;
        UnLoadEvent.OnEventRaised -= OnUnLoad;
        CloseTargetEvent.OnEventRaised -= OnCloseTarget;
        TrackDeathEvent.OnTransformEventRaised -= OnTrackDeath;
    }
}
