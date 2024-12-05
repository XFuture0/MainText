using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Hit : MonoBehaviour,IDestroyed
{
    private DeadBlock deadBlock;
    public float Speed;
    public GameObject own;
    public Rigidbody2D rb;
    [Header("¼ÆÊ±Æ÷")]
    public float time;
    private float time_count;
    [Header("¹ã²¥")]
    public AudioEventSO DeadAudioEvent;
    public AudioClip DeadClip;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        deadBlock = GetComponent<DeadBlock>();
    }
    private void OnEnable()
    {
        time_count = time;
    }
    private void FixedUpdate()
    {
        time_count -= Time.deltaTime;
        rb.velocity = new Vector2(Speed * Time.deltaTime, 0);
        if(time_count <= 0)
        {
            Destroy(own);
        }
        if (!deadBlock.isHitsth)
        {
            DeadAudioEvent.AudioRaiseEvent(DeadClip);
            Destroy(own);
        }
    }
    public void DestoryAction()
    {
        Destroy(own);
    }
}
