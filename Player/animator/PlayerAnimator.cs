using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator Playeranim;
    private void Awake()
    {
        Playeranim = GetComponent<Animator>();
    }
    private void Update()
    {
        Animaton();
    }

    private void Animaton()
    {
   
    }
}
