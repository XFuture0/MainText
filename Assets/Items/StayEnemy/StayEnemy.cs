using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayEnemy : MonoBehaviour
{
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO TimeStopEnemyEvent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="PlayerHit")
        {
            Debug.Log("Hit");
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
