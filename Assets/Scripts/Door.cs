using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    void OnEnable()
    {
        DoorTrigger.openDoor += ToggleState;
    }

    void ToggleState()
    {
        LeanTween.rotateY(gameObject, 70f, 1f);
    }

    void OnDisable()
    {
       DoorTrigger.openDoor -= ToggleState;
    }
}
