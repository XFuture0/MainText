using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_Sign : MonoBehaviour
{
    public SpriteRenderer WalkSprite;
    public Sprite ChangeSprite;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO FindPlayer;
    private void OnEnable()
    {
        FindPlayer.OnEventRaised += OnFindPlayer;
    }

    private void OnFindPlayer()
    {
        WalkSprite.sprite = ChangeSprite;
        StartCoroutine(Wait_Time());
    }

    private void OnDisable()
    {
        FindPlayer.OnEventRaised -= OnFindPlayer;
    }
    public IEnumerator Wait_Time()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
