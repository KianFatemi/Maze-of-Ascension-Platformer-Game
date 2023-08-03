using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public static PlayerJump instance;
    [SerializeField]
    AudioClip clip;
    public static Action<int, AudioClip> jumpSound;
    private bool isJumping;
    Rigidbody rig;
    [SerializeField]
    float jumpForce = 5.0f;
    [SerializeField]
    string floorTag = "Floor";
    [SerializeField, Range(1, 10)]
    float jumpGravityScale = 10.0f;
    

    void Awake()
    {

        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);



        }
        rig = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        InputManager.jump += Jump;
    }

    void Jump(float state)
    {
        
        if (!isJumping)
        {
            if (state == 1)
            {
                rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                
                isJumping = true; //set jumping to true
                
                jumpSound?.Invoke(1,clip);
            }
            if (isJumping == true) 
            { rig.AddForce(Vector3.down * jumpGravityScale * rig.mass, ForceMode.Impulse); }
        }
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(floorTag)) //detects if player hits floor
        {
            isJumping = false; //sets jumping to false
        }
    }

    void OnDisable()
    {
        InputManager.jump -= Jump;  
    }
    
}
