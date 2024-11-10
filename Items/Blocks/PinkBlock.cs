using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBlock : MonoBehaviour
{
    public SpriteRenderer ThisSprite;
    public Sprite OpenSprite;
    public Sprite CloseSprite;
    public Collider2D Collider;
    private float Change_time;
    private bool isChange;
    [Header("¹ã²¥")]
    public VoidEventSO ChangeSprite;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO ChangeSprite_Pink;
    private void Awake()
    {
        ThisSprite = GetComponent<SpriteRenderer>();
        isChange = true;
    }
    private void Update()
    {
        Change_time += Time.deltaTime;
        if (Change_time > 3 && !isChange)
        {
            Collider.enabled = false;
            ThisSprite.sprite = CloseSprite;
            isChange = true;
            ChangeSprite.RaiseEvent();
        }
    }
    private void OnEnable()
    {
        ChangeSprite_Pink.OnEventRaised += Change_Pink;
    }

    private void Change_Pink()
    {
        Collider.enabled = true;
        ThisSprite.sprite = OpenSprite;
        Change_time = 0;
        isChange = false;
    }

    private void OnDisable()
    {
        ChangeSprite_Pink.OnEventRaised -= Change_Pink;
    }
}