using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashShadow : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer thisSprite;
    private SpriteRenderer playerSprite;
    [Header("时间控制参数")]
    public float ActiveTime;
    public float ActiveStart;
    [Header("颜色控制")]
    private Color color;
    private float alpha;
    public float alphaSet;
    public float alphaMultiplier;
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        alpha = alphaSet;
        thisSprite.sprite = playerSprite.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        transform.localScale = player.localScale;
        ActiveStart = Time.time;
    }
    private void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(0.5f, 0.5f, 1,alpha);
        thisSprite.color = color;
        if (Time.time >= ActiveTime + ActiveStart)
        {
           ShadowPool.instance.ReturnPool(this.gameObject);//返回对象池
        }
    }
}
