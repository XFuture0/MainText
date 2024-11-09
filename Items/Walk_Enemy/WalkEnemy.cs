using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WalkEnemy : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    [Header("广播")]
    public VoidEventSO DeadEvent;
    public VoidEventSO FindPlayer;
    [Header("检测人物")]
    private Vector3 Face;
    public Vector2 BoxCastPosition;
    public Vector2 CheckSize;
    public float instance;
    public LayerMask Player;
    public bool findPlayer;
    [Header("怪物属性")]
    public float EnemySpeed;
    public bool isLeft;
    public bool isRight;
    public Vector2 Left;
    public Vector2 Right;
    public LayerMask isGround;
        private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DeadEvent?.RaiseEvent();
        }
    }
    private void Update()
    {
        Check();
    }
    private void FixedUpdate()
    {
        ChaseState();
        if (findPlayer)
        {
            rb.velocity = new Vector2(Face.x * EnemySpeed * Time.deltaTime, rb.velocity.y);
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
            anim.SetBool("FindPlayer", true);
            findPlayer = true;
        }
        if (isLeft)
        {
             transform.localScale = new Vector3(1, 1, 1);
            Face = new Vector3(transform.localScale.x, 0, 0);
        }
        if (isRight)
        {
             transform.localScale = new Vector3(-1, 1, 1);
            Face = new Vector3(transform.localScale.x, 0, 0);
        }
    }
    public void Check()
    {
        isLeft = Physics2D.OverlapCircle((Vector2)transform.position + Left, 0.25f,isGround);
        isRight = Physics2D.OverlapCircle((Vector2)transform.position + Right, 0.25f,isGround);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + (Vector3)Left, 0.25f);
        Gizmos.DrawWireSphere(transform.position + (Vector3)Right, 0.25f);
        Gizmos.DrawWireSphere(transform.position + (Vector3)BoxCastPosition + new Vector3(instance * transform.localScale.x, 0, 0), 0.25f);
    }
}
