using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    [Header("检查点")]
    public bool IsGround;
    [Header("地面Check")]
    public Vector2 Left_Up_position;
    public Vector2 Right_Down_position;
    public float GroundR;
    public LayerMask ground;
    private void Update()
    {
        Checking();
    }

    private void Checking()
    {
        IsGround = Physics2D.OverlapArea((Vector2)transform.position + Left_Up_position,(Vector2)transform.position + Right_Down_position,ground);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + Left_Up_position, GroundR);
        Gizmos.DrawWireSphere((Vector2)transform.position + Right_Down_position, GroundR);
    }
 }
