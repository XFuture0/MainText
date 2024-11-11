using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]//�˵����Ͳ˵�·��(����)
public class inventory : ScriptableObject
{
    public List<ItemDetails> PrecentItemList = new List<ItemDetails>();//�������б��ʾÿһ��ItemDetails��
    public ItemDetails GetItemDetails(Item_name itemname)
    {
        return PrecentItemList.Find(i => i.item_Name == itemname);//(Ѱ���Ƿ������ItemName)
    }
}
[System.Serializable]
public class ItemDetails
{
    public Item_name item_Name;
    public Sprite itemSprite;
}