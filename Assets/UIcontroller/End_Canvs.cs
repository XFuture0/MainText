using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class End_Canvs : MonoBehaviour
{
    public InputPlayController inputActions;
    public GameObject End_canvs;
    public GameObject End_Tip;
    public Text Dead_Count;
    public Text Collection_Count;
    private float deadCount;
    private float collectionCount;
    public AudioClip DeadClip;
    public AudioClip CollectionClip;
    [Header("广播")]
    public VoidEventSO EndDataEvent;
    public VoidEventSO ClosePlayerEvent;
    public VoidEventSO ReturnMainMenuEvent;
    public AudioEventSO DeadCountAudioEvent;
    public AudioEventSO CollectionCountAudioEvent;
    [Header("事件监听")]
    public FlaotEventSO PlayDeadCountEvent;
    public FlaotEventSO CollectionCountEvent;
    [Header("评价")]
    public GameObject Comment1;
    public GameObject Comment2;
    public GameObject Comment3;
    public GameObject Comment4;
    public GameObject Comment5;
    private void Awake()
    {
        inputActions = new InputPlayController();
        inputActions.Enable();
    }

    private void ReturnMainMenu(InputAction.CallbackContext context)
    {
        ReturnMainMenuEvent.RaiseEvent();
        this.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        PlayDeadCountEvent.OnFloatEventRaised += OnGetDeadCountData;
        CollectionCountEvent.OnFloatEventRaised += OnGetCollectionCount;
        EndDataEvent.RaiseEvent();
    }
    private void OnGetCollectionCount(float collectioncount)
    {
        collectionCount = collectioncount;
    }
    private IEnumerator AddCollcetionCount()
    {
        for(int i = 0;i <= collectionCount; i++)
        {
            Collection_Count.text = i.ToString();
            if (i > 0)
            {
                CollectionCountAudioEvent.AudioRaiseEvent(CollectionClip);
            }
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(OpenTip());
    }
    private void OnGetDeadCountData(float deadcount)
    {
        deadCount = deadcount;
        ClosePlayerEvent.RaiseEvent();
        StartCoroutine(AddDeadCount());
    }
    private IEnumerator AddDeadCount()
    {
        for (int i = 0; i <= deadCount; i++)
        {
            Dead_Count.text = i.ToString();
            DeadCountAudioEvent.AudioRaiseEvent(DeadClip);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(AddCollcetionCount());
    }
    private IEnumerator OpenTip()
    {
        GetComment();
        yield return new WaitForSeconds(2f);
        End_Tip.SetActive(true);
        inputActions.UI.In.started += ReturnMainMenu;
    }
    private void OnDisable()
    {
        PlayDeadCountEvent.OnFloatEventRaised -= OnGetDeadCountData;
        CollectionCountEvent.OnFloatEventRaised -= OnGetCollectionCount;
        inputActions.UI.In.started -= ReturnMainMenu;
    }
    private void GetComment()
    {
        if(deadCount < 10 && collectionCount == 3)
        {
            Comment5.SetActive(true);
        }
        else if(deadCount >= 0 && deadCount < 30)
        {
            Comment4.SetActive(true);
        }
        else if(deadCount >= 30 &&  deadCount < 50)
        {
            Comment3.SetActive(true);
        }
        else if(deadCount >= 50 && deadCount < 70)
        {
            Comment2.SetActive(true);
        }
        else if(deadCount >= 70)
        {
            Comment1.SetActive(true);
        }

    }
}
