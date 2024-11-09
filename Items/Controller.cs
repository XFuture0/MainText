using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour, Iinteractive
{
    private TranSpotController TranSpotEvent;
    private SpriteRenderer spriterenderer;
    private Sprite CurrentSprite;
    public Sprite OpenSprite;
    public Sprite CloseSprite;
    public GameObject Light;
    public bool isTranSpot;
    [HideInInspector]public bool isCloseDoor;
    private void Awake()
    {
        TranSpotEvent = GetComponent<TranSpotController>();
        spriterenderer = GetComponent<SpriteRenderer>();
        CurrentSprite = CloseSprite;
    }
    public void TriggerAction()
    {
        spriterenderer.sprite = CloseSprite;
        gameObject.tag = ("Untagged");
        Light.SetActive(true);
        CLoseDoor();
        if (isTranSpot)
        {
            TranSpotEvent.OpenTransform();
        }
    }
    public void CLoseDoor()
    {
        isCloseDoor = true;
    }
}
