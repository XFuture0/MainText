using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBlock : MonoBehaviour
{
    private bool isHitsth;
    [Header("¹ã²¥")]
    public VoidEventSO DeadEvent;
    public VoidEventSO NoDeadEvent;
    private void Awake()
    {
        isHitsth = true;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isHitsth)
        {
            Debug.Log("1");
            isHitsth = false;
            if (!(gameObject.tag == "CanDestory"))
            {
                DeadEvent?.RaiseEvent();
            }
            if(gameObject.tag == "CanDestory")
            {
                NoDeadEvent?.RaiseEvent();
            }
            StartCoroutine(WaitTime());
        }
    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5f);
        isHitsth = true;
    }
}
