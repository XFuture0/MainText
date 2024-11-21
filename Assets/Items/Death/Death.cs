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
    [Header("计时器")]
    public float time;
    private float time_count;
    [Header("事件监听")]
    public TransformEventSO PlayerPositionEvent;
    private void Awake()
    {
        time_count = time;
       anim = GetComponent<Animator>();
    }
    private void Update()
    {
        time_count -= Time.deltaTime;
        if (time_count < 0)
        {
            n = UnityEngine.Random.Range(1, 2);
            time_count = time;
        }
        if(n == 1)
        {
            anim.SetTrigger("Hit");
            n = 0;
        }
        if (n == 2)
        {
            Mode2();
            n = 0;
        }
    }
    private void OnEnable()
    {
        PlayerPositionEvent.OnTransformEventRaised += OnGetPositon;
    }

    private void OnGetPositon(Transform Position)
    {
        gameObject.transform.localPosition = new Vector3(Position.position.x + PositionAdjust_X, Position.position.y + PositionAdjust_Y, 0);
    }

    private void OnDisable()
    {
        PlayerPositionEvent.OnTransformEventRaised -= OnGetPositon;
    }
    private void Mode1()
    {
        Instantiate(Hit,new Vector3(transform.position.x + HitAdjust_X , transform.position.y,transform.position.z),Quaternion.identity);
    }
    private void Mode2()
    {
        
    }
}
