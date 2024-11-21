using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Hit : MonoBehaviour,IDestroyed
{
    public float Speed;
    public GameObject own;
    public Rigidbody2D rb;
    [Header("¼ÆÊ±Æ÷")]
    public float time;
    private float time_count;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }

    public void DestoryAction()
    {
        Destroy(own);
    }
}
