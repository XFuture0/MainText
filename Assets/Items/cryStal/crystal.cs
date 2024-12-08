using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystal : MonoBehaviour
{
    public Sprite CloseSprite;
    public Sprite OpenSprite;
    public SpriteRenderer ChangeSprite;
    public Collider2D closeCollider;
    private bool isGet;
    [Header("¹ã²¥")]
    public VoidEventSO IncreaseEnergyEvent;
    public AudioEventSO CrystalAudioEvent;
    public AudioClip Clip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isGet)
        {
            isGet = true;
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
        isGet = false;
    }
}
