using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorController : MonoBehaviour
{
    public Controller controller;
    public string DoorName;
    [Header("¹ã²¥")]
    public StringEventSO OpenDoor;
    private void Awake()
    {
        controller = GetComponent<Controller>();
    }
    private void Update()
    {
        if (controller.isCloseDoor)
        {
            OpenDoor?.StringRaiseEvent(DoorName);
            controller.isCloseDoor = false;
        }
    }
}
