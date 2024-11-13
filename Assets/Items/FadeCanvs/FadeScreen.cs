using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public Animator Fadeanim;
    public GameObject PlayerTemp;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO FadeinEvent;
    private void Awake()
    {
        Fadeanim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        FadeinEvent.OnEventRaised += OnFadein;
    }

    private void OnFadein()
    {
        Fadeanim.SetTrigger("Fadein");
        StartCoroutine(Fadeout());
    }
    private IEnumerator Fadeout()
    {
        yield return new WaitForSeconds(5f);
        PlayerTemp.SetActive(false);
        Fadeanim.SetTrigger("Fadeout");
    }
    private void OnDisable()
    {
        FadeinEvent.OnEventRaised -= OnFadein;
    }
    public void PlayerOn()
    {
        PlayerTemp.SetActive(true);
    }
}
