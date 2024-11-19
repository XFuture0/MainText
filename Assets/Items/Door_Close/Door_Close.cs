using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Close : MonoBehaviour
{
    public Animator anim;
    public StringEventSO OpenDoor;
    public Collider2D this_Collider;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        OpenDoor.OnStringEventRaised += OnOpenDoor;
    }

    private void OnOpenDoor(string doorname)
    {
        if (this.gameObject.name == doorname)
        {
            anim.SetTrigger("Open");
            this_Collider.enabled = false;
        }
    }
    private void OnDisable()
    {
        OpenDoor.OnStringEventRaised -= OnOpenDoor;
    }
}
