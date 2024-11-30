using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Emoji_Controller : MonoBehaviour
{
    public Transform Player;
    public GameObject Emoji_Canvs;
    public GameObject Emoji_worry_temp;
    private bool isHaveEmoji_worry;
    private bool isOpen;
    public InputPlayController inputActions;
    public Image OwnImage;
    public Sprite Emoji_worry;
    [Header("事件监听")]
    public VoidEventSO GetEmoji_worryEvent;
    [Header("计时器")]
    public float time;
    private float Time_count;
    private float Emoji_Time = 0.1f;
    private float Emoji_Time_count;
    private void Awake()
    {
        inputActions = new InputPlayController();
        Time_count = time;
        Emoji_Time_count = Emoji_Time;
    }
    private void Update()
    {
        if (Time_count >= -1)
        {
            Emoji_worry_temp.transform.localScale = Player.localScale;
            Emoji_worry_temp.transform.position = new Vector3(Player.position.x + (float)0.9,Player.position.y + (float)0.45,Player.position.z);
            Time_count -= Time.deltaTime;
        }
        if (Time_count <= 0)
        {
            Emoji_worry_temp.SetActive(false);
        }
        if (isOpen)
        {
            if (Emoji_Time_count > -1)
            {
                Emoji_Time_count -= Time.deltaTime;
            }
            if (Emoji_Time_count <= 0)
            {
                Emoji_Canvs.SetActive(true);
            }
        }
    }
    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.UI.Item.performed += OpenEmoji;
        inputActions.UI.Item.canceled += CloseEmoji;
        GetEmoji_worryEvent.OnEventRaised += OnGetEmoji_worry;
    }
    private void CloseEmoji(InputAction.CallbackContext context)
    {
        isOpen = false;
        Emoji_Time_count = Emoji_Time;
        if (Emoji_Time_count > 0)
        {
            if (isHaveEmoji_worry)
            {
                Emoji_worry_temp.SetActive(true);
                Time_count = time;
            }
        }
        Emoji_Canvs.SetActive(false);
    }

    private void OpenEmoji(InputAction.CallbackContext context)
    {
        Emoji_Time_count = Emoji_Time;
        isOpen = true;
    }
    private void OnGetEmoji_worry()
    {
        isHaveEmoji_worry = true;
        OwnImage.color = new Color(1, 1, 1, 1);
        OwnImage.sprite = Emoji_worry;
    }
    private void OnDisable()
    {
        GetEmoji_worryEvent.OnEventRaised -= OnGetEmoji_worry;
    }
}
