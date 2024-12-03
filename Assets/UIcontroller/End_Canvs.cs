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
    [Header("¹ã²¥")]
    public VoidEventSO EndDataEvent;
    public VoidEventSO ClosePlayerEvent;
    public VoidEventSO ReturnMainMenuEvent;
    [Header("ÊÂ¼þ¼àÌý")]
    public FlaotEventSO PlayDeadCountEvent;
    public FlaotEventSO CollectionCountEvent;
    private void Awake()
    {
        inputActions = new InputPlayController();
        inputActions.Enable();
        inputActions.UI.In.started += ReturnMainMenu;
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
        Collection_Count.text = collectioncount.ToString();
        StartCoroutine(OpenTip());
    }
    private void OnGetDeadCountData(float deadcount)
    {
        Dead_Count.text = deadcount.ToString();
        ClosePlayerEvent.RaiseEvent();
    }

    private IEnumerator OpenTip()
    {
        yield return new WaitForSeconds(2f);
        End_Tip.SetActive(true);
    }
    private void OnDisable()
    {
        PlayDeadCountEvent.OnFloatEventRaised -= OnGetDeadCountData;
        CollectionCountEvent.OnFloatEventRaised -= OnGetCollectionCount;
        inputActions.UI.In.started -= ReturnMainMenu;
    }
}
