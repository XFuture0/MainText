using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyManager : MonoBehaviour
{
    [Header("�¼�����")]
    public FlaotEventSO PowerChangeEvent;
    public Image PowerImage;
    private void OnEnable()
    {
        PowerChangeEvent.OnFloatEventRaised += PowerChange;
    }
    public void PowerChange(float power)
    {
        PowerImage.fillAmount = power;
    }
    private void OnDisable()
    {
        PowerChangeEvent.OnFloatEventRaised -= PowerChange;
    }
}
