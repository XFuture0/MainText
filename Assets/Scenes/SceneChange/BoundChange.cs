using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundChange : MonoBehaviour
{
    private CinemachineConfiner2D Confiner2D;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO BoundChangeEvent;
    private void Awake()
    {
        Confiner2D = GetComponent<CinemachineConfiner2D>();
        var obj = GameObject.FindGameObjectWithTag("Bound");
        if (obj == null)
        {
            return;
        }
        Confiner2D.m_BoundingShape2D = obj.GetComponent<Collider2D>();
        Confiner2D.InvalidateCache();
    }
    private void OnEnable()
    {
        BoundChangeEvent.OnEventRaised += GetBoundChange;
    }
    private void OnDisable()
    {
        BoundChangeEvent.OnEventRaised -= GetBoundChange;
    }
    private void GetBoundChange()
    {
        var obj = GameObject.FindGameObjectWithTag("Bound");
        if (obj == null)
        {
            return;
        }
        Confiner2D.m_BoundingShape2D = obj.GetComponent<Collider2D>();
        Confiner2D.InvalidateCache();
    }
}
