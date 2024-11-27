using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystal : MonoBehaviour
{
    public Sprite CloseSprite;
    public Sprite OpenSprite;
    public SpriteRenderer ChangeSprite;
    public Collider2D closeCollider;
    [Header("�㲥")]
    public VoidEventSO IncreaseEnergyEvent;
    public AudioEventSO CrystalAudioEvent;
    public AudioClip Clip;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ChangeSprite.sprite = CloseSprite;
            closeCollider.enabled = false;
            CrystalAudioEvent.AudioRaiseEvent(Clip);
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
