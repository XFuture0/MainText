using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DishTemp : MonoBehaviour, Iinteractive
{
    public Rigidbody2D rb;
    public Collider2D Opencollider;
    public Collider2D Fixcollider;
    public AudioClip Clip;
    public GameObject Tip_Dish;
    private bool canGet;
    [Header("¹ã²¥")]
    public VoidEventSO GetDishEvent;
    public AudioEventSO GetDishAudioEvent;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO ThrowDashEvent;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        canGet = false;
    }
    private void OnEnable()
    {
        ThrowDashEvent.OnEventRaised += OnThrowDish;
    }
    private void OnThrowDish()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = new Vector2((float)1.5, 3);
        StartCoroutine(GetDish());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canGet)
        {
            Tip_Dish.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Tip_Dish.SetActive(false);
    }
    private IEnumerator GetDish()
    {
        yield return new WaitForSeconds(1.5f);
        rb.bodyType = RigidbodyType2D.Static;
        this.gameObject.layer = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Fixcollider.enabled = false;
        Opencollider.enabled = true;
        canGet = true;
    }
    private void OnDisable()
    {
        ThrowDashEvent.OnEventRaised -= OnThrowDish;
    }
    public void TriggerAction()
    {
        GetDishEvent.RaiseEvent();
        GetDishAudioEvent.AudioRaiseEvent(Clip);
        Destroy(gameObject);
    }
}
