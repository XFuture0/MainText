using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    private Rigidbody2D rb;
    private float DishFace;
    public AudioClip Clip;
    [Header("�㲥")]
    public AudioEventSO ThrowDishEvent;
    [Header("�¼�����")]
    public FlaotEventSO DishCastEvent;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        DishFace = 0;
    }
    private void FixedUpdate()
    {
        if (DishFace != 0)
        {
            rb.velocity = new Vector2(DishFace * 3, 0);
        }
    }
    private void OnEnable()
    {
        DishCastEvent.OnFloatEventRaised += OnCastDish;
        ThrowDishEvent.AudioRaiseEvent(Clip);
    }

    private void OnCastDish(float Face)
    {
        DishFace = Face;
    }
    private void OnDisable()
    {
        DishCastEvent.OnFloatEventRaised -= OnCastDish;
    }
}
