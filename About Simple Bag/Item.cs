using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    public Item_name itemName;//ÎïÆ·Ãû
    public void GetItem()
    {
        inventory_manager.instance.AddItem(itemName);
        this.gameObject.SetActive(false);
    }
}