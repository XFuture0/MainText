using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public ItemDetails Current_slotitem;//格子的物品
    public Image Current_slotImage;//格子的图片
    public void SetupSlot(ItemDetails item)
    {
        Current_slotitem = item;
        this.gameObject.SetActive(true);
        Current_slotImage.sprite = item.itemSprite;
    }
    public void SetEmpty()
    {
        this.gameObject.SetActive(false);
    }
}
