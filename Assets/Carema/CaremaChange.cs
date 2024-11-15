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
    public float SizeChange_X;
    public float SizeChange_Z;
    public bool isPressX;
    public bool isPressZ;
    private GameObject FirseSelecting;
    [Header("ÊÂ¼þ¼àÌý")]
    public TransformEventSO Press_X_TransformEvent;
    public TransformEventSO Press_Z_TransformEvent;
    public GameObjectEventSO FirstSelectEvent;
    [Header("¹ã²¥")]
    public VoidEventSO ReturnEvent;
    public VoidEventSO X_In_Event;
    private void Awake()
    {
        Current_Tranform.name = "Newtree";
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
        if (target.name != Current_Tranform.name)
        {
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
    }
    private IEnumerator Transform_Z_Position()
    {
        yield return new WaitForSeconds(0.5f);
        VirtualCamera.Follow = Current_Tranform;
        VirtualCamera.LookAt = Current_Tranform;
    }
    private void OnDisable()
    {
        Press_X_TransformEvent.OnTransformEventRaised -= OnPress_X_TransformEvent;
        Press_Z_TransformEvent.OnTransformEventRaised -= OnPress_Z_TransformEvent;
        FirstSelectEvent.OnGameObjectEventRaised -= OnFirstSelect;
    }
}
