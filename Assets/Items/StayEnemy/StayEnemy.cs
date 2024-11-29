using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StayEnemy : MonoBehaviour
{
    public GameObject HitPart;
    public Image EnemyHealthBlue;
    public AudioClip Clip;
    [Header("�㲥")]
    public AudioEventSO DeadEvent;
    [Header("����Ѫ��")]
    public int EnemyHealth;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="PlayerHit")
        {
            Instantiate(HitPart, transform.position, Quaternion.identity);
            EnemyHealth--;
            EnemyHealthBlue.fillAmount -= (float)0.167;
            if (EnemyHealth <= 0)
            {
                Time.timeScale = 1f;
                DeadEvent.AudioRaiseEvent(Clip);
                Destroy(gameObject);
            }
        }
    }
}
