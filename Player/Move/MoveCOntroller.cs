using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.InputSystem;
public class MoveCOntroller : MonoBehaviour
{
    public InputPlayController inputActions;
    private Rigidbody2D rb;
    private Check check;
    public Animator anim;
    private Vector2 MoveMent;
    private float PlayerFace;
    [Header("人物属性")]
    public float PlayerSpeed;
    [Header("人物跳跃")]
    public float StartJump;
    private float Jump_time;
    public float Target_Jump_Time;
    private bool isJump;
    public float OnJump;
    [Header("人物冲刺")]
    public float DashPower;
    public float DashPower_High;
    public float DashTime;
    public float Dash_count;
    private bool isDash;
    private Vector2 Forpower;
    private float MainGravity;
   [HideInInspector] public float DashTimeCount;
   [HideInInspector] public float FullDashPower;
    private bool isPressW;
    private bool isPressS;
    private bool isPressA;
    private bool isPressD;
    [Header("广播")]
    public FlaotEventSO PowerChangeEvent;
    public AudioEventSO DashAudioEvent;
    public AudioEventSO JumpAudioEvent;
    public AudioClip DashClip;
    public AudioClip JumpClip;
    
    public void Awake()
    {
        inputActions = new InputPlayController();
        rb = GetComponent<Rigidbody2D>();
        check = GetComponent<Check>();
        anim = GetComponent<Animator>();
        inputActions.Player.Jump.performed += Jumps;
        inputActions.Player.Jump.canceled += CancelJumps;
        inputActions.Player.Cash.started += Dash;
        inputActions.Player.UP.performed += OnUP;
        inputActions.Player.UP.canceled += CancelUP;
        inputActions.Player.Down.performed += OnDown;
        inputActions.Player.Down.canceled += CancelDown;
        inputActions.Enable();
        Jump_time = 0;
        DashTimeCount = 2 * Dash_count;
        FullDashPower = 2 * Dash_count;
        MainGravity = rb.gravityScale;
    }
    private void Update()
    {
        var Power_presentage = DashTimeCount / FullDashPower;
        PowerChangeEvent?.FloatRaiseEvent(Power_presentage);
    }
    void FixedUpdate()
    {
        if (!isDash)
        {
            Move();
            if (DashTimeCount < 2 * Dash_count)
            {
                DashTimeCount += Time.deltaTime;
            }
        }
        if (isDash)
        {
            ShadowPool.instance.GetFromPool();//单例
        }
        if (isJump && Jump_time < Target_Jump_Time)
        {
            Jump_time += Time.deltaTime;
            rb.velocity = new Vector2(rb.velocity.x,OnJump + StartJump * Jump_time);
        }
        else if (!isJump || Jump_time > Target_Jump_Time)
        {
            Jump_time = 0;
            isJump = false;
        }
    }

    private void Move()
    {
        MoveMent = inputActions.Player.Move.ReadValue<Vector2>();
        rb.velocity = new Vector2(MoveMent.x * PlayerSpeed * Time.deltaTime, rb.velocity.y);
        anim.SetFloat("PlaySpeed",math.abs(rb.velocity.x));
        PlayerFace = (int)transform.localScale.x;
        if (MoveMent.x > 0)
        {
            PlayerFace = 1;
            isPressD = true;
            isPressA = false;
        }
        else if (MoveMent.x < 0)
        {
            PlayerFace = -1;
            isPressD = false;
            isPressA = true;
        }
        else
        {
            isPressA = false;
            isPressD = false;
        }
        transform.localScale = new Vector3(PlayerFace, 1, 1);
    }
    private void Jumps(InputAction.CallbackContext context)
    {
        if (check.IsGround)
        {
            isJump = true;
            JumpAudioEvent.AudioRaiseEvent(JumpClip);
        }
    }
    private void CancelJumps(InputAction.CallbackContext context)
    {
        isJump = false;
    }
    private void OnDown(InputAction.CallbackContext context)
    {
        isPressS = true;
    }

    private void OnUP(InputAction.CallbackContext context)
    {
        isPressW = true;
    }
    private void CancelDown(InputAction.CallbackContext context)
    {
        isPressS = false;
    }

    private void CancelUP(InputAction.CallbackContext context)
    {
        isPressW = false;
    }
    private void Dash(InputAction.CallbackContext context)
    {
        if (DashTimeCount >= 2)
        {
            DashTimeCount -= 2;
            DashAudioEvent.AudioRaiseEvent(DashClip);
            StartCoroutine(Dashing());
        }
    }
    public IEnumerator Dashing()
    {
        rb.gravityScale = 0;
        isDash = true;
        Forpower = new Vector2(gameObject.transform.localScale.x * DashPower, 0);
        if (isPressW && !(isPressA || isPressD))
        {
            Forpower = new Vector2(0, DashPower_High);
        }
        if (isPressS && !(isPressA || isPressD))
        {
            Forpower = new Vector2(0, -DashPower_High);
        }
        if (isPressW && (isPressA || isPressD))
        {
            Forpower = new Vector2(gameObject.transform.localScale.x * DashPower, DashPower_High);
        }
        if (isPressS && (isPressA || isPressD))
        {
            Forpower = new Vector2(gameObject.transform.localScale.x * DashPower, -DashPower_High);
        }
        rb.velocity = Forpower;
        yield return new WaitForSeconds(DashTime);
        rb.gravityScale = MainGravity;
        rb.velocity = new Vector2(rb.velocity.x, 1);
        isDash = false;
    }
    //这是一条测试注释
}
