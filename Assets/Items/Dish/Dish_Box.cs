using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish_Box : MonoBehaviour
{
    public GameObject Dish;
    [Header("¹ã²¥")]
    public VoidEventSO CanpressQEvent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            StartCoroutine(WaitTime());
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Bound")
        {
            StartCoroutine(WaitTime());
        }
    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1f);
        CanpressQEvent.RaiseEvent();
        Destroy(Dish);
    }
}
