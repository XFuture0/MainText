using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3 : MonoBehaviour
{
    public void DestroyOwn()
    {
        Destroy(this.gameObject);
    }
}
