using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public ItemDetails Current_slotitem;//���ӵ���Ʒ
    public Image Current_slotImage;//���ӵ�ͼƬ
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
