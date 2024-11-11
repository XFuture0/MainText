using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSetting : MonoBehaviour, IDestroyed
{
    public void DestoryAction()
    {
        this.gameObject.SetActive(false);
    }
}
