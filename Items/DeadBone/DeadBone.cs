using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DeadBone : MonoBehaviour, Iinteractive
{
    public SpriteRenderer Sprite;
    public GameObject DeadLight;
    [Header("¹ã²¥")]
    public VoidEventSO ThrowFlashEvent;
    private void Awake()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }
    public void TriggerAction()
    {
        DeadLight.gameObject.SetActive(false);
        gameObject.tag = ("Untagged");
        Sprite.sortingOrder = 0;
        ThrowFlashEvent?.RaiseEvent();
    }
}
