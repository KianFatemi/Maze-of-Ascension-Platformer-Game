using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Transform teleportPosition;
    float increment = 1;
    float invokeTime = 0;

  
    private void OnEnable()
    {
        StartTimerTrigger.startCountdown += StartTimer;
        StopTimerTrigger.stopCountdown += StopTimer;
    }

    void StartTimer()
    {
         InvokeRepeating("InvokeTimer", 0, increment);
        
        
    }

    void InvokeTimer()
    {
        invokeTime = invokeTime + increment;

        Debug.Log(" " + invokeTime);
        if (invokeTime == 25)
        {
            Debug.Log("Teleport");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(126f, 33f, 387f);
            StopTimer();
        }
        
    }
    
    void StopTimer()
    {
        CancelInvoke("InvokeTimer");
       
    }
    

    void OnDisable()
    {
        StartTimerTrigger.startCountdown -= StartTimer;
        StopTimerTrigger.stopCountdown -= StopTimer;
    }
}
