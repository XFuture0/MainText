using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    public GameObject Collection_Canvs;
    public TextMeshProUGUI NumBertext;
    [Header("¹ã²¥")]
    public FlaotEventSO CollectionCountEvent;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO CollectionAddEvent;
    public VoidEventSO EndDataEvent;
    public int Num;
    private void Awake()
    {
        Num = 0;
    }
    private void OnEnable()
    {
        CollectionAddEvent.OnEventRaised += AddNumber;
        EndDataEvent.OnEventRaised += OnCastEndData;
    }

    private void OnCastEndData()
    {
        CollectionCountEvent.FloatRaiseEvent(Num);
    }

    private void AddNumber()
    {
        Collection_Canvs.SetActive(true);
        Num++;
        NumBertext.text = Num.ToString();
        StartCoroutine(CloseCanvs());
    }
    private IEnumerator CloseCanvs()
    {
        yield return new WaitForSeconds(5f);
        Collection_Canvs.SetActive(false);
    }
    private void OnDisable()
    {
        CollectionAddEvent.OnEventRaised -= AddNumber;
        EndDataEvent.OnEventRaised -= OnCastEndData;
    }
}
