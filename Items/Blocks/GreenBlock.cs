using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBlock : MonoBehaviour
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
    public VoidEventSO ChangeSprite_Green;
    private void Awake()
    {
        ThisSprite = GetComponent<SpriteRenderer>();
        Change_time = 0;
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
        ChangeSprite_Green.OnEventRaised += Change_Green;
    }

    private void Change_Green()
    {
        Collider.enabled = true;
        ThisSprite.sprite = OpenSprite;
        Change_time = 0;
        isChange = false;
    }

    private void OnDisable()
    {
        ChangeSprite_Green.OnEventRaised -= Change_Green;
    }
}
