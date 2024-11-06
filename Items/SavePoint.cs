using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SavePoint : MonoBehaviour,Iinteractive
{
    [Header("¹ã²¥")]
    public AudioEventSO AudioEventFX;

    public AudioClip Clip;
    public Animator anim;
    public GameObject SaveLight;
    public float waitLightTime;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void TriggerAction()
    {
        anim.SetTrigger("isSave");
        gameObject.tag = ("Untagged");
        AudioEventFX.AudioRaiseEvent(Clip);
        StartCoroutine(OpenLight());
    }
    private IEnumerator OpenLight()
    {
        yield return new WaitForSeconds(waitLightTime);
        SaveLight.SetActive(true);
    }

}
