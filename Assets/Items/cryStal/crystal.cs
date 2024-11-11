using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystal : MonoBehaviour
{
    public Sprite CloseSprite;
    public Sprite OpenSprite;
    public SpriteRenderer ChangeSprite;
    public Collider2D closeCollider;
    [Header("¹ã²¥")]
    public VoidEventSO IncreaseEnergyEvent;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ChangeSprite.sprite = CloseSprite;
            closeCollider.enabled = false;
            IncreaseEnergyEvent.RaiseEvent();
            StartCoroutine(ReStart());
        }
    }
    public IEnumerator ReStart()
    {
        yield return new WaitForSecondsRealtime(5f);
        ChangeSprite.sprite = OpenSprite;
        closeCollider.enabled = true;
    }
}
