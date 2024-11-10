using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/TranItemEventSO")]
public class TranItemEventSO : ScriptableObject//将ItemDetails传给UI显示
{
    public UnityAction<ItemDetails,int> OnTranItemEventRaised;
    public void TranItemRaiseEvent(ItemDetails item,int index)
    {
        OnTranItemEventRaised?.Invoke(item,index);
    }
}
