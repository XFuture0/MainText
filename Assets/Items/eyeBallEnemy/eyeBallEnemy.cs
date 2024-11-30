using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class eyeBallEnemy : MonoBehaviour
{
    public State Nowstate;
    public State Hidestate;
    public State Rushstate;
    public State Walkstate;
    public State Waitstate;
    public Vector3 direction;
    public Collider2D FindPlayer;
    public Collider2D HitSth;
    public Animator anim;
    public Rigidbody2D rb;
    public GameObject eyeSign;
    public bool isRush;
    [HideInInspector]public bool isFindPlayer;
    [HideInInspector]public Transform PlayerPosition;
    [Header("计时器")]
    public float time;
    public float Time_Count;
    [Header("广播")]
    public VoidEventSO FindPlayerEvent;
    public VoidEventSO EyeEnemyRushEvent;
    public VoidEventSO EyeEnemyNoRushEvent;
    public VoidEventSO CaremaImpulseEvent;
    [Header("事件监听")]
    public TransformEventSO PlayerPositionEvent;
    public VoidEventSO eyeJumpEvent;
    public VoidEventSO DeadEvent;
    [Header("属性")]
    public float RushSpeed;
    public float SpeedBet;
    private void Awake()
    {
        Hidestate = new eyeEnemyHide();
        Rushstate = new eyeEnemyRush();
        Walkstate = new eyeEnemyWalk();
        Waitstate = new WaitState();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Nowstate = Hidestate;
        Nowstate.OnEnter(this);
        Time_Count = time;
    }
    private void Update()
    {
        Nowstate.LogicUpdate(this);
        if (Nowstate != Waitstate)
        {
            Time_Count -= Time.deltaTime;
        }
        if(Nowstate == Rushstate)
        {
            isRush = true;
            EyeEnemyRushEvent.RaiseEvent();
        }
        if(Nowstate != Rushstate)
        {
            isRush = false;
            EyeEnemyNoRushEvent.RaiseEvent();
        }
    }
    private void FixedUpdate()
    {
        Nowstate.PhysicsUpdate(this);
    }
    public void SwitchState(StateType state)
    {
        var newState = state switch
        {
            StateType.Hide => Hidestate,
            StateType.Rush => Rushstate,
            StateType.Walk => Walkstate,
            StateType.Wait => Waitstate,
            _ => null
        };
        Nowstate.OnExit(this);
        Nowstate = newState;
        Nowstate.OnEnter(this);
        Time_Count = time;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (Nowstate == Hidestate)
            {
                isFindPlayer = true;
                SwitchState(StateType.Walk);
            }
        }
        if(HitSth.enabled == true && other.gameObject.layer == 6)
        {
            SwitchState(StateType.Walk);
        }
    }
    private void OnEnable()
    {
        PlayerPositionEvent.OnTransformEventRaised += OnPlayerPosition;
        eyeJumpEvent.OnEventRaised += OnJump_eye;
        DeadEvent.OnEventRaised += Ondead;
    }

    private void Ondead()
    {
        SwitchState(StateType.Wait);
        StartCoroutine(DeadWait());
    }
    private IEnumerator DeadWait()
    {
        yield return new WaitForSeconds(6f);
        SwitchState(StateType.Walk);
    }

    private void OnJump_eye()
    {
        SwitchState(StateType.Wait);
        anim.SetTrigger("Hit");
        StartCoroutine(Wait_Time());
    }
    private IEnumerator Wait_Time()
    {
        yield return new WaitForSeconds(1f);
        SwitchState(StateType.Walk);
    }
    private void OnPlayerPosition(Transform Player)
    {
        if (Nowstate == Walkstate)
        {
            PlayerPosition = Player;
            direction = (PlayerPosition.position - transform.position).normalized;
            if (direction.x < 0 && transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            if (direction.x > 0 && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            rb.velocity = (Vector2)direction * RushSpeed;
        }
    }
    public void RushPlayer()
    {
        rb.velocity = (Vector2)direction * RushSpeed * SpeedBet;
    }
    private void OnDisable()
    {
        PlayerPositionEvent.OnTransformEventRaised -= OnPlayerPosition;
        eyeJumpEvent.OnEventRaised -= OnJump_eye;
        DeadEvent.OnEventRaised -= Ondead;
    }
}
