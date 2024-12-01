using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.InputSystem;
public class MoveCOntroller : MonoBehaviour
{
    public InputPlayController inputActions;
    private Rigidbody2D rb;
    private Check check;
    public Animator anim;
    public Transform own;
    public bool isGetDish;
    [Header("附属物")]
    public GameObject Dish;
    public GameObject Attack3;
    public GameObject PlayerBloom;
    public GameObject UpBall;
    public GameObject SpeedRound;
    [HideInInspector] public IDestroyed CanDestory_Item;
    private Vector2 MoveMent;
    private float PlayerFace;
    private float Current_Boom_time;
    private bool isBoomFront;
    public bool isBoomHigh;
    private float BoomHighPower;
    [Header("人物属性")]
    public float PlayerSpeed;
    private float CurrentPlayerSpeed;
    public int Combo;
    private bool isAttack;
    private bool isSpeedRound;
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
    private bool canPressQ;
    [Header("广播")]
    public VoidEventSO CaremaImpulseEvent;
    public FlaotEventSO PowerChangeEvent;
    public FlaotEventSO DishCastEvent;
    public AudioEventSO DashAudioEvent;
    public AudioEventSO JumpAudioEvent;
    public AudioEventSO PlayerAttack3AudioEvent;
    public AudioEventSO DeadAudioEvent;
    public AudioClip DashClip;
    public AudioClip JumpClip;
    public AudioClip PlayerAttack3Clip;
    public AudioClip DeadClip;
    public VoidEventSO RestartEvent;
    public VoidEventSO FadeinEvent;
    public TransformEventSO PlayerPositionEvent;
    [Header("人物死亡")]
    public bool isDead;
    [Header("事件监听")]
    public VoidEventSO DeadEvent;
    public VoidEventSO NoDeadEvent;
    public VoidEventSO IncreaseEnergyEvent;
    public GravityEventSO BoomSpeed;
    public GravityEventSO BoomHigh;
    public VoidEventSO DeadRestart;
    public VoidEventSO StopPlayerEvent;
    public VoidEventSO ContinuePlayerEvent;
    public VoidEventSO FindPlayerEvent;
    public VoidEventSO eyeJumpEvent;
    public VoidEventSO CanPressQEvent;
    public VoidEventSO GetDishEvent;
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
        inputActions.Player.Move.performed += OnAD;
        inputActions.Player.Move.canceled += CancelAD;
        inputActions.Player.Throw.started += ThrowDish;
        inputActions.Player.Attack.started += PlayerAttack;
        inputActions.Enable();
        Jump_time = 0;
        DashTimeCount = 2 * Dash_count;
        FullDashPower = 2 * Dash_count;
        MainGravity = rb.gravityScale;
        CurrentPlayerSpeed = PlayerSpeed;
        canPressQ = true;
        isAttack = true;
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
        if (!isSpeedRound)
        {
            isSpeedRound = true;
            if (rb.velocity.x > 12)
            {
                var SpeedRound_Start = new Vector3(transform.position.x - (float)0.5, transform.position.y, transform.position.z);
                Instantiate(SpeedRound,SpeedRound_Start,quaternion.identity);
            }
            if (rb.velocity.x < -12)
            {
                var SpeedRound_Start = new Vector3(transform.position.x + (float)0.5, transform.position.y, transform.position.z);
                Instantiate(SpeedRound, SpeedRound_Start, quaternion.identity);
            }
            StartCoroutine(SpeedRound_Restart());
        }
    }
    void FixedUpdate()
    {
        if (!isDash && !isDead)
        {
            if (DashTimeCount < 2 * Dash_count)
            {
                DashTimeCount += Time.deltaTime;
            }
            if (!isBoomFront && !isBoomHigh)
            {
                Move();
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
            if (check.IsHitSth)
            {
                isBoomFront = false;
                rb.gravityScale = MainGravity;
            }
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
            if (check.IsHitSth)
            {
                isBoomHigh = false;
                rb.gravityScale = MainGravity;
            }
            rb.velocity = new Vector2(0, BoomHighPower);
            if (isPressA)
            {
                rb.velocity = new Vector2(-5, rb.velocity.y);
            }
            if (isPressD)
            {
                rb.velocity = new Vector2(5, rb.velocity.y);
            }
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
    private void OnAD(InputAction.CallbackContext context)
    {
      var AD = inputActions.Player.Move.ReadValue<Vector2>();
        if (AD.x < 0)
        {
            isPressA = true;
        }
        if (AD.x > 0)
        {
            isPressD = true;
        }
    }
    private void CancelAD(InputAction.CallbackContext context)
    {
        isPressA = false;
        isPressD = false;
    }
    private void Dash(InputAction.CallbackContext context)
    {
        if (DashTimeCount >= 2)
        {
            if (isPressW && !(isPressA || isPressD))
            {
                Instantiate(SpeedRound, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            }
            else if (isPressS && !(isPressA || isPressD))
            {
                Instantiate(SpeedRound, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            }
            else
            {
                Instantiate(SpeedRound, transform.position, quaternion.identity);
            }
            DashTimeCount -= 2;
            rb.gravityScale = 0;
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
        rb.gravityScale = MainGravity;
        rb.velocity = new Vector2(rb.velocity.x, 1);
        isDash = false;
    }
    private void PlayerAttack(InputAction.CallbackContext context)
    {
        if (isAttack)
        {
            isAttack = false;
            Combo++;
            anim.SetInteger("combo", Combo);
            StartCoroutine(AttackWaitTime());
        }
    }
    private IEnumerator AttackWaitTime()
    {
        if(Combo == 3)
        {
            PlayerBloom.SetActive(true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            inputActions.Player.Disable();
            yield return new WaitForSeconds(2.7f);
        }
        yield return new WaitForSeconds(0.5f);
        isAttack = true;
        anim.SetInteger("combo",0);
        if (Combo == 3)
        {
            PlayerBloom.SetActive(false);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            inputActions.Player.Enable();
            Combo = 0;
        }
    }
    public void OnAttack3()
    {
        var Attack3Position = new Vector3(0, 0, 0);
        if (transform.localScale.x < 0)
        {
            Attack3Position = new Vector3(transform.position.x + (float)-1, transform.position.y, transform.position.z);
            var Quat = new quaternion(0,0,1,0);
            Instantiate(Attack3, Attack3Position, Quat);
        }
        if (transform.localScale.x > 0)
        {
            Attack3Position = new Vector3(transform.position.x + (float)1, transform.position.y, transform.position.z);
            var Quat = new quaternion(0, 0,0,1);
            Instantiate(Attack3, Attack3Position, Quat);
        }
        StartCoroutine(BackTime());
    }
    private IEnumerator BackTime()
    {
        yield return new WaitForSeconds(1.2f);
        Time.timeScale = 1f;
    }
    public void OnAttack3Audio()
    {
        Time.timeScale = 0.5f;
        PlayerAttack3AudioEvent.AudioRaiseEvent(PlayerAttack3Clip);
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "CanDestory" && isDash)
        {
            CanDestory_Item = other.GetComponent<IDestroyed>();
            CanDestory_Item.DestoryAction();
        }
    }
    private void ThrowDish(InputAction.CallbackContext context)
    {
        if (isGetDish)
        {
            if (canPressQ)
            {
                var DishPosition = new Vector3(0, 0, 0);
                if (transform.localScale.x < 0)
                {
                    DishPosition = new Vector3(transform.position.x + (float)-0.55, transform.position.y, transform.position.z);
                }
                if (transform.localScale.x > 0)
                {
                    DishPosition = new Vector3(transform.position.x + (float)0.55, transform.position.y, transform.position.z);
                }
                Instantiate(Dish, DishPosition, quaternion.identity);
                DishCastEvent.FloatRaiseEvent(transform.localScale.x);
                canPressQ = false;
            }
        }
    }
    private void OnEnable()
    {
        DeadEvent.OnEventRaised += Dead;
        NoDeadEvent.OnEventRaised += NoDead;
        IncreaseEnergyEvent.OnEventRaised += OnIncreaseEnergy;
        BoomSpeed.OnGravityEventRaised += OnBoomSpeed;
        BoomHigh.OnGravityEventRaised += OnBoomHigh;
        DeadRestart.OnEventRaised += OnDeadRestart;
        StopPlayerEvent.OnEventRaised += OnStopPlayer;
        ContinuePlayerEvent.OnEventRaised += OnContinuePlayer;
        FindPlayerEvent.OnEventRaised += OnFindPlayer;
        eyeJumpEvent.OnEventRaised += PlayerJump_eye;
        CanPressQEvent.OnEventRaised += OnCanPressQ;
        GetDishEvent.OnEventRaised += OnGetDash;
    }

    private void OnGetDash()
    {
        isGetDish = true;
    }

    private void OnCanPressQ()
    {
        canPressQ = true;
    }

    private void PlayerJump_eye()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(transform.up * 15,ForceMode2D.Impulse);
    }

    private void OnFindPlayer()
    {
        PlayerPositionEvent.TransformRaiseEvent(own);
    }
    private void OnContinuePlayer()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        inputActions.Player.Enable();
        rb.velocity = new Vector2(0, -5);
    }
    private void OnStopPlayer()
    {
        inputActions.Player.Disable();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnDeadRestart()
    {
        isDead = false;
    }

    private void OnBoomHigh(float BoomHighing, float Boom_time)
    {
        UpBall.SetActive(true);
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
        UpBall.SetActive(false);
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
            DeadAudioEvent.AudioRaiseEvent(DeadClip);
            anim.SetTrigger("Dead");
            isDead = true;
            inputActions.Disable();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            FadeinEvent.RaiseEvent();
            StartCoroutine(Restart());
        }
    }
    private void NoDead()
    {
        if (!isDash)
        {
            if (!isDead)
            {
                anim.SetTrigger("Dead");
                isDead = true;
                inputActions.Disable();
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                FadeinEvent.RaiseEvent();
                StartCoroutine(Restart());
            }
        }
    }
    private IEnumerator SpeedRound_Restart()
    {
        yield return new WaitForSeconds(0.3f);
        isSpeedRound = false;
    }
    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
        RestartEvent.RaiseEvent();
        yield return new WaitForSeconds(3f);
        anim.SetTrigger("Revive");
        yield return new WaitForSeconds(1f);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        inputActions.Enable();
    }
    private void OnDisable()
    {
        DeadEvent.OnEventRaised -= Dead;
        NoDeadEvent.OnEventRaised -= NoDead;
        IncreaseEnergyEvent.OnEventRaised -= OnIncreaseEnergy;
        BoomSpeed.OnGravityEventRaised -= OnBoomSpeed;
        BoomHigh.OnGravityEventRaised -= OnBoomHigh;
        DeadRestart.OnEventRaised -= OnDeadRestart;
        StopPlayerEvent.OnEventRaised -= OnStopPlayer;
        ContinuePlayerEvent.OnEventRaised = OnContinuePlayer;
        FindPlayerEvent.OnEventRaised -= OnFindPlayer;
        eyeJumpEvent.OnEventRaised -= PlayerJump_eye;
        CanPressQEvent.OnEventRaised -= OnCanPressQ;
        GetDishEvent.OnEventRaised -= OnGetDash;
    }
}
