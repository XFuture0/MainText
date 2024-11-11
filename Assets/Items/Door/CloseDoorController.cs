using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorController : MonoBehaviour
{
    public Controller controller;
    [Header("�㲥")]
    public VoidEventSO CloseDoor;
    private void Awake()
    {
        controller = GetComponent<Controller>();
    }
    private void Update()
    {
        if (controller.isCloseDoor)
        {
            CloseDoor?.RaiseEvent();
            controller.isCloseDoor = false;
        }
    }
}
