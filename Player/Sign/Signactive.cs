using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Signactive : MonoBehaviour
{
    [Header("¹ã²¥")]
    public AudioEventSO PressEvent; 

    public InputPlayController inputActions;
    public GameObject SignSprite;
    public Transform PlayerScale;
    public Animator Playeranim;
    public AudioClip PressAudio;
    [HideInInspector]public bool canPress;
    [HideInInspector] public Iinteractive TargetItem;
    private void Awake()
    {
        inputActions = new InputPlayController();
        Playeranim = GetComponent<Animator>();
        inputActions.Player.Press.started += CanPress;
        inputActions.Enable();
    }

    private void CanPress(InputAction.CallbackContext context)
    {
        Playeranim.SetTrigger("Press");
        PressEvent.AudioRaiseEvent(PressAudio);
        if (canPress)
        {
            TargetItem.TriggerAction();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("interactable"))
        {
            canPress = true;
            TargetItem = other.GetComponent<Iinteractive>();
        }
    }
    private void Update()
    {
        SignSprite.SetActive(canPress);
        SignSprite.transform.localScale = PlayerScale.localScale;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canPress = false;
    }
}
