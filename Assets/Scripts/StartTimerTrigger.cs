using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartTimerTrigger : MonoBehaviour
{
    public static Action startCountdown;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InvokeStartCountdown();
        }
    }

    void InvokeStartCountdown()
    {
        
        startCountdown?.Invoke();
    }
}
