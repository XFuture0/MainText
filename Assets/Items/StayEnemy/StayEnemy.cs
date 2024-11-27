using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StayEnemy : MonoBehaviour
{
    public GameObject HitPart;
    public Image EnemyHealthBlue;
    [Header("事件监听")]
    public VoidEventSO TimeStopEnemyEvent;
    [Header("怪物血量")]
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
                Destroy(gameObject);
            }
        }
    }
    private void OnEnable()
    {
        TimeStopEnemyEvent.OnEventRaised += OnTimeStop;
    }
    private void OnTimeStop()
    {
        Time.timeScale = 0.5f;
        StartCoroutine(WaitTime());
    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(3.2f);
        Time.timeScale = 1f;
    }
    private void OnDisable()
    {
        TimeStopEnemyEvent.OnEventRaised -= OnTimeStop;
    }
}
