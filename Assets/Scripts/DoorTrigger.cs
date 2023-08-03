using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public static Action openDoor;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            InvokeOpenDoor();
        }
    }

    void InvokeOpenDoor()
    {
        openDoor?.Invoke(); 
    }
}
