using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/TranItemEventSO")]
public class TranItemEventSO : ScriptableObject//��ItemDetails����UI��ʾ
{
    public UnityAction<ItemDetails,int> OnTranItemEventRaised;
    public void TranItemRaiseEvent(ItemDetails item,int index)
    {
        OnTranItemEventRaised?.Invoke(item,index);
    }
}
