using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GetEmoji_Box : MonoBehaviour
{
    public GameObject Emoji_Box;
    public Image Back_Box;
    public Image Back;
    public GameObject TipText;
    private float WideLength;
    private bool IsOpen;
    private bool IsCome;
    [Header("¹ã²¥")]
    public VoidEventSO OpenText1z2z2Event;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO GetEmoji_worryEvent;
    private void OnEnable()
    {
        WideLength = 1;
        GetEmoji_worryEvent.OnEventRaised += OnGetEmoji;
    }

    private void OnGetEmoji()
    {
        Emoji_Box.SetActive(true);
    }

    private void Update()
    {
        if(Emoji_Box.activeSelf == true)
        {
            IsOpen = true;
        }
    }
    private void FixedUpdate()
    {
        if (IsOpen)
        {
            if (WideLength < 15)
            {
                WideLength *= (float)1.1;
                Back.rectTransform.localScale = new Vector3(WideLength, 1, 1);
                Back_Box.rectTransform.localScale = new Vector3(WideLength, 1, 1);
            }
            if (WideLength > 15)
            {
                if (!IsCome)
                {
                    IsOpen = false;
                    IsCome = true;
                    TipText.SetActive(true);
                    StartCoroutine(WaitTime());
                }
            }
        }
    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(3f);
        OpenText1z2z2Event.RaiseEvent();
        Emoji_Box.SetActive(false);
    }
    private void OnDisable()
    {
        GetEmoji_worryEvent.OnEventRaised -= OnGetEmoji;
    }
}
