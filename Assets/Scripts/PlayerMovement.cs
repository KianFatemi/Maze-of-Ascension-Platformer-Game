using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool disabled = false;
    Vector2 dir;
    Rigidbody rig;
    Vector3 forceDirection = Vector3.zero;
    [SerializeField]
    private float movementForce = 1f;
    [SerializeField]
    private float maxSpeed = 5f;
    private InputAction move;
    [SerializeField]
    private Camera playerCamera;
    


    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    
    void OnEnable()
    {
        InputManager.move += Move;
        Cursor.visible = false;
    }
    
    void Move(Vector2 dir)
    {
        this.dir = dir;
    }
    

    private void FixedUpdate()
    {
        if (!disabled)
        {
            forceDirection += dir.x * GetCameraRight(playerCamera) * movementForce;
            forceDirection += dir.y * GetCameraForward(playerCamera) * movementForce;

            rig.AddForce(forceDirection, ForceMode.Impulse);
            forceDirection = Vector3.zero;

            if (rig.velocity.y < 0f)
                rig.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

            Vector3 horizontalVelocity = rig.velocity;
            horizontalVelocity.y = 0;
            if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
                rig.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rig.velocity.y;

            LookAt();
        }
       
    }

    private void LookAt()
    {
        Vector3 direction = rig.velocity;
        direction.y = 0f;

        if (dir.sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this.rig.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            rig.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    void OnDisable()
    {
        InputManager.move -= Move;
        Cursor.visible = true;
    }
}
