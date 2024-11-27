using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;

public class BoomUp : MonoBehaviour
{
    public GravityEventSO BoomHigh;
    public Animator anim;
    public float BoomHighing;
    public float Boom_Time;
    private bool isboom;
    [Header("¹ã²¥")]
    public AudioEventSO BoomUpEvent;
    public AudioClip Clip;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Open", true);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!isboom)
            {
                anim.SetBool("Open", false);
                BoomUpEvent.AudioRaiseEvent(Clip);
                BoomHigh.GravityEventRaised(BoomHighing, Boom_Time);
                isboom = true;
                StartCoroutine(WaitTime());
            }
        }
    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5f);
        anim.SetBool("Open", true);
        isboom = false;
    }
}
