using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Magnet : MonoBehaviour, Iinteractive
{
    public Item item;
    private void Awake()
    {
        item = GetComponent<Item>();
    }
    public void TriggerAction()
    {
        item.GetItem();
    }
}
