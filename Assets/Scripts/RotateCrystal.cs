using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCrystal : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 5f;
    bool goingup = true;
    [SerializeField]
    float floatSpeed;
    float floatTimer;
    [SerializeField]
    float floatRate;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);

        floatTimer += Time.deltaTime;
        Vector3 Dir = new Vector3(0f, floatSpeed, 0);
        transform.Translate(Dir);

        if(goingup && floatTimer >= floatRate)
        {
            goingup = false;
            floatTimer = 0;
            floatSpeed = -floatSpeed;
        }

        if (!goingup && floatTimer >= floatRate)
        {
            goingup = true;
            floatTimer = 0;
            floatSpeed = -floatSpeed;
        }

    }
}
