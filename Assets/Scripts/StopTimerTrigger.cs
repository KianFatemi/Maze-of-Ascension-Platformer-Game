using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StopTimerTrigger : MonoBehaviour
{
    public static Action stopCountdown;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InvokeStopCountdown();
        }
    }

    void InvokeStopCountdown()
    {
        stopCountdown?.Invoke();
    }
}
