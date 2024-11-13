using Cinemachine;
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
    [HideInInspector] public IDestroyed CanDestory_Item;
    private Vector2 MoveMent;
    private float PlayerFace;
    private float Current_Boom_time;
    private bool isBoomFront;
    private bool isBoomHigh;
    private float BoomHighPower;
    [Header("人物属性")]
    public float PlayerSpeed;
    private float CurrentPlayerSpeed;
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
    public VoidEventSO CaremaImpulseEvent;
    public FlaotEventSO PowerChangeEvent;
    public AudioEventSO DashAudioEvent;
    public AudioEventSO JumpAudioEvent;
    public AudioClip DashClip;
    public AudioClip JumpClip;
    public VoidEventSO RestartEvent;
    public VoidEventSO FadeinEvent;
    [Header("人物死亡")]
    public bool isDead;
    [Header("事件监听")]
    public VoidEventSO DeadEvent;
    public VoidEventSO IncreaseEnergyEvent;
    public GravityEventSO BoomSpeed;
    public GravityEventSO BoomHigh;
    public VoidEventSO DeadRestart;
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
        CurrentPlayerSpeed = PlayerSpeed;
    }
    private void Update()
    {
        var Power_presentage = DashTimeCount / FullDashPower;
        PowerChangeEvent?.FloatRaiseEvent(Power_presentage);
        if (DashTimeCount > 2 * Dash_count)
        {
            DashTimeCount = 2 * Dash_count;
        }
        anim.SetFloat("PlaySpeed", math.abs(rb.velocity.x));
    }
    void FixedUpdate()
    {
        
        if (!isDash && !isBoomFront && !isBoomHigh)
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
        if (isBoomFront)
        {
            rb.velocity = new Vector2(-PlayerSpeed * Time.deltaTime, 0);
            if (isPressW)
            {
                rb.velocity = new Vector2(rb.velocity.x, 5);
            }
            if (isPressS)
            {
                rb.velocity = new Vector2(rb.velocity.x, -5);
            }
        }
        if (isBoomHigh)
        {
            rb.velocity = new Vector2(0, BoomHighPower);
        }
    }

    private void Move()
    {
        MoveMent = inputActions.Player.Move.ReadValue<Vector2>();
        rb.velocity = new Vector2(MoveMent.x * PlayerSpeed * Time.deltaTime, rb.velocity.y);
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
        CaremaImpulseEvent.RaiseEvent();
        yield return new WaitForSeconds(DashTime);
        rb.velocity = new Vector2(rb.velocity.x, 1);
        isDash = false;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "CanDestory" && isDash)
        {
            CanDestory_Item = other.GetComponent<IDestroyed>();
            CanDestory_Item.DestoryAction();
        }
    }
    private void OnEnable()
    {
        DeadEvent.OnEventRaised += Dead;
        IncreaseEnergyEvent.OnEventRaised += OnIncreaseEnergy;
        BoomSpeed.OnGravityEventRaised += OnBoomSpeed;
        BoomHigh.OnGravityEventRaised += OnBoomHigh;
        DeadRestart.OnEventRaised += OnDeadRestart;
    }

    private void OnDeadRestart()
    {
        isDead = false;
    }

    private void OnBoomHigh(float BoomHighing, float Boom_time)
    {
        rb.gravityScale = 0;
        isBoomHigh = true;
        BoomHighPower = BoomHighing;
        Current_Boom_time = Boom_time;
        StartCoroutine(BoomHigh_Over());
    }
    private IEnumerator BoomHigh_Over()
    {
        yield return new WaitForSeconds(Current_Boom_time);
        rb.gravityScale = MainGravity;
        isBoomHigh = false;
    }
    private void OnBoomSpeed(float BoomSpeeding,float Boom_time)
    {
        rb.gravityScale = 0;
        isBoomFront = true;
        transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        PlayerSpeed = BoomSpeeding;
        Current_Boom_time = Boom_time;
        StartCoroutine(BoomFront_Over());
    }
    private IEnumerator BoomFront_Over()
    {
        yield return new WaitForSeconds(Current_Boom_time);
        rb.gravityScale = MainGravity;
        PlayerSpeed = CurrentPlayerSpeed;
        isBoomFront = false;
    }
    private void OnIncreaseEnergy()
    {
        DashTimeCount += 2;
    }

    private void Dead()
    {
        if (!isDead)
        {
            isDead = true;
            inputActions.Disable();
            FadeinEvent.RaiseEvent();
            StartCoroutine(Restart());
        }
    }
    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
        RestartEvent.RaiseEvent();
        yield return new WaitForSeconds(3f);
        inputActions.Enable();
    }
    private void OnDisable()
    {
        DeadEvent.OnEventRaised -= Dead;
        IncreaseEnergyEvent.OnEventRaised -= OnIncreaseEnergy;
        BoomSpeed.OnGravityEventRaised -= OnBoomSpeed;
        BoomHigh.OnGravityEventRaised -= OnBoomHigh;
        DeadRestart.OnEventRaised -= OnDeadRestart;
    }
}
