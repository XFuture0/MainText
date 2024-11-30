using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float PositionAdjust_X;
    public float PositionAdjust_Y;
    public float HitAdjust_X;
    public GameObject Hit;
    private int n = 0;
    private Animator anim;
    private bool IsOpen;
    private bool canMove;
    [Header("计时器")]
    public float time;
    private float time_count;
    public float Starttime;
    private float Starttime_count;
    [Header("广播")]
    public VoidEventSO LookPlayerEvent;
    [Header("事件监听")]
    public TransformEventSO PlayerPositionEvent;
    private void Awake()
    {
        canMove = true;
        IsOpen = false;
        time_count = time;
        Starttime_count = Starttime;
       anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (IsOpen)
        {
            time_count -= Time.deltaTime;
            if (time_count < 0)
            {
                n = UnityEngine.Random.Range(1, 2);
                time_count = time;
            }
            if (n == 1)
            {
                anim.SetTrigger("Hit");
                n = 0;
            }
        }
        if (canMove)
        {
            Starttime_count -= Time.deltaTime;
            if(Starttime_count < 0)
            {
                LookPlayerEvent.RaiseEvent();
                StartCoroutine(WaitTime());
            }
            gameObject.transform.position = new Vector3(transform.position.x + (float)0.01, transform.position.y, transform.position.z);
        }
    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.1f);
        IsOpen = true;
    }
    private void OnEnable()
    {
        PlayerPositionEvent.OnTransformEventRaised += OnGetPositon;
        
    }

    private void OnGetPositon(Transform Position)
    {
        if (IsOpen)
        {
            gameObject.transform.localPosition = new Vector3(Position.position.x + PositionAdjust_X, Position.position.y + PositionAdjust_Y, 0);
        }
    }

    private void OnDisable()
    {
        PlayerPositionEvent.OnTransformEventRaised -= OnGetPositon;
    }
    private void Mode1()
    {
        Instantiate(Hit,new Vector3(transform.position.x + HitAdjust_X , transform.position.y,transform.position.z),Quaternion.identity);
    }
}
