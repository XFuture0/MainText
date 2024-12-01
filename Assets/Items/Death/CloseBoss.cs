using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBoss : MonoBehaviour
{
    public GameObject Boss1z2z9;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Boss1z2z9.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
