using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    [Header("����")]
    public bool IsGround;
    [Header("����Check")]
    public Vector2 Left_Up_position;
    public Vector2 Right_Down_position;
    private float GroundR;
    public LayerMask ground;
    private void FixedUpdate()
    {
        Checking();
    }

    private void Checking()
    {
        IsGround = Physics2D.OverlapArea((Vector2)transform.position + Left_Up_position,(Vector2)transform.position + Right_Down_position,ground);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + Left_Up_position, 0.05f);
        Gizmos.DrawWireSphere((Vector2)transform.position + Right_Down_position, 0.05f);
    }
 }
