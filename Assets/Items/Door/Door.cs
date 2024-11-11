using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject DoorClose;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO Close;
   [HideInInspector] public Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        Close.OnEventRaised += CloseDoor;
    }
    private void OnDisable()
    {
        Close.OnEventRaised -= CloseDoor;
    }
    public void CloseDoor()
    {
        anim.SetTrigger("CloseDoor");
    }
    public void SetCollider()
    {
        DoorClose.SetActive(true);
    }
}
