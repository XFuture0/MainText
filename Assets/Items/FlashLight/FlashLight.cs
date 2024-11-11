using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class FlashLight : MonoBehaviour,Iinteractive
{
    public Item item;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO ThrowFalshEventing;
    public Rigidbody2D rb;
    public float ForcePower;
    public GameObject FlashsLight;
    public Collider2D closeCollider;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        item = GetComponent<Item>();
    }
    private void OnEnable()
    {
        ThrowFalshEventing.OnEventRaised += ThrowFlashLight;
    }

    private void ThrowFlashLight()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(transform.up * ForcePower, ForceMode2D.Impulse);
        FlashsLight.SetActive(true);
        StartCoroutine(StopMove());
    }
    public IEnumerator StopMove()
    {
        yield return new WaitForSeconds(2.5f);
        rb.bodyType = RigidbodyType2D.Static;
        closeCollider.enabled = false;
        gameObject.layer = 0;
        gameObject.tag = "interactable";
    }
    private void OnDisable()
    {
        ThrowFalshEventing.OnEventRaised -= ThrowFlashLight;
    }

    public void TriggerAction()
    {
        item.GetItem();
    }
}
