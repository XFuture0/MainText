using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]//菜单名和菜单路径(背包)
public class inventory : ScriptableObject
{
    public List<ItemDetails> PrecentItemList = new List<ItemDetails>();//背包（列表表示每一个ItemDetails）
    public ItemDetails GetItemDetails(Item_name itemname)
    {
        return PrecentItemList.Find(i => i.item_Name == itemname);//(寻找是否有这个ItemName)
    }
}
[System.Serializable]
public class ItemDetails
{
    public Item_name item_Name;
    public Sprite itemSprite;
}