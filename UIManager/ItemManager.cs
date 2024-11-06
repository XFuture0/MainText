using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
public class ItemManager : MonoBehaviour
{
    public int currentIndex;//ÐòºÅ
    public GameObject Sloted;
    public Slot slot;
    public inventory thisbag;
    [Header("ÊÂ¼þ¼àÌý")]
    public TranItemEventSO TranItem;
    [Header("¹ã²¥")]
    public FlaotEventSO SwitchItem;
    private void OnEnable()
    {
        TranItem.OnTranItemEventRaised += SetupItem;
    }

    private void SetupItem(ItemDetails item,int current_index)
    {
        if (item == null)
        {
            slot.SetEmpty();
            currentIndex = -1;
            SwitchItem.FloatRaiseEvent(currentIndex);
        }
        else
        {
            currentIndex = current_index;
            SwitchItem.FloatRaiseEvent(currentIndex);
            slot.SetupSlot(item);
        }
    }

    private void OnDisable()
    {
        TranItem.OnTranItemEventRaised -= SetupItem;
    }
}
