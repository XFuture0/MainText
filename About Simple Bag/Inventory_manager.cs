using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class inventory_manager : MonoBehaviour
{
    public FlaotEventSO ChangeItemEvent;
    public GameObject Sloted;
    public inventory itemData;
    public static inventory_manager instance;//ʹ�õ���
    public List<Item_name> ItemList = new List<Item_name>();//�����������Ʒ���б�
    [Header("�㲥")]
    public TranItemEventSO tranItem;
    private void Awake()
    {
        instance = this;
    }
    public void AddItem(Item_name item)
    {
       if (!ItemList.Contains(item))
        {
            ItemList.Add(item);
            tranItem.TranItemRaiseEvent(itemData.GetItemDetails(item),ItemList.Count - 1);//�б�����-1 == ��ǰ����������˳��
        }
    }
    private void OnEnable()
    {
        ChangeItemEvent.OnFloatEventRaised += ChangeItem;
    }

    private void ChangeItem(float index)
    {
        if (index >= 0 && index < ItemList.Count)
        {
            ItemDetails item = itemData.GetItemDetails(ItemList[(int)index]);
            tranItem.TranItemRaiseEvent(item, (int)index);
        }
    }

    private void OnDisable()
    {
        ChangeItemEvent.OnFloatEventRaised -= ChangeItem;
    }
}