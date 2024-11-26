using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WalkEnemy : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    [Header("π„≤•")]
    public VoidEventSO FindPlayer;
    [Header("ºÏ≤‚»ÀŒÔ")]
    private Vector3 Face;
    public Vector2 BoxCastPosition;
    public Vector2 CheckSize;
    public float instance;
    public LayerMask Player;
    public bool findPlayer;
        private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        ChaseState();
        if (findPlayer)
        {
            FindPlayer?.RaiseEvent();
        }
    }
    public bool FoundPlayer()
    {
        Face = new Vector3(transform.localScale.x, 0, 0);
        return Physics2D.BoxCast((Vector2)transform.position + BoxCastPosition, CheckSize, 0, (Vector2)Face, instance, Player);
    }
    public void ChaseState()
    {
        if (FoundPlayer())
        {
            findPlayer = true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + (Vector3)BoxCastPosition + new Vector3(instance * transform.localScale.x, 0, 0), 0.25f);
    }
}
