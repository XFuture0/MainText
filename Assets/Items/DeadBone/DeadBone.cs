using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DeadBone : MonoBehaviour, Iinteractive
{
    public GameObject DeadLight;
    [Header("�㲥")]
    public VoidEventSO ThrowDashEvent;
    public void TriggerAction()
    {
        this.gameObject.tag = "Untagged";
        DeadLight.gameObject.SetActive(false);
        ThrowDashEvent?.RaiseEvent();
    }
}
