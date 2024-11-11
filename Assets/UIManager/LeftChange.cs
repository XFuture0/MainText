using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class LeftChange : MonoBehaviour
{
    [Header("广播")]
    public FlaotEventSO ChangeItemEvent;
    [Header("事件监听")]
    public FlaotEventSO Switchitem;
    public ItemManager itemManager;
    public InputPlayController inputActions;
    public int current_index;
    private void Awake()
    {
        current_index = -2;
        itemManager = GetComponent<ItemManager>();
        inputActions = new InputPlayController();
        inputActions.Player.LeftChange.started += Leftchange;
        inputActions.Enable();
    }
    private void OnEnable()
    {
        Switchitem.OnFloatEventRaised += Switchindex;
    }

    private void Switchindex(float index)
    {
        current_index = (int)index;
    }

    private void OnDisable()
    {
        Switchitem.OnFloatEventRaised -= Switchindex;
    }
    private void Leftchange(InputAction.CallbackContext context)
    {
        SwitchItem();
    }
    public void SwitchItem()
    {
        var tempIndex = current_index - 1;
        ChangeItemEvent.FloatRaiseEvent(tempIndex);//将新序号传进去
    }
}
