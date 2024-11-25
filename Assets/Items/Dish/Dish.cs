using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    private Rigidbody2D rb;
    private float DishFace;
    [Header("ÊÂ¼þ¼àÌý")]
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
