using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPart : MonoBehaviour
{
    public void DestoryOwn()
    {
        Destroy(gameObject);
    }
}
