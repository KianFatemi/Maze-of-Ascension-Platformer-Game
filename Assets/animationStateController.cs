using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isJumpingHash;
    int isGroundedHash;
    int isFallingHash;

    // Adjust this to the length of the raycast to check for grounding
    public float groundedRaycastLength = 0.2f;

    // Minimum distance for the falling animation to trigger
    public float minimumFallingDistance = 1.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isJumpingHash = Animator.StringToHash("isJumping");
        isGroundedHash = Animator.StringToHash("isGrounded");
        isFallingHash = Animator.StringToHash("isFalling");
    }

    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isJumping = animator.GetBool(isJumpingHash);

        // Check if any movement key (W, A, S, D) is pressed
        bool movementPressed = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d");

        // Set the "isWalking" parameter based on movement input
        animator.SetBool(isWalkingHash, movementPressed);

        // Check if the jump key (space) is pressed and the character is grounded
        if (Input.GetKey(KeyCode.Space))
        {
            // Trigger the jumping animation by setting the "isJumping" parameter to true
            animator.SetBool(isJumpingHash, true);
        }

        // Check if the character is falling (not grounded) and not moving
        bool isFalling = !IsGrounded() && !isWalking;

        // Check if the character is falling from a certain height
        if (isFalling)
        {
            float distanceToGround = DistanceToGround();
            isFalling = distanceToGround >= minimumFallingDistance;
        }

        animator.SetBool(isFallingHash, isFalling);

        // Reset the "isJumping" parameter if the character is grounded
        if (IsGrounded())
        {
            animator.SetBool(isJumpingHash, false);
        }
    }

    bool IsGrounded()
    {
        // Perform a raycast downward to check if the character is grounded
        return Physics.Raycast(transform.position, Vector3.down, groundedRaycastLength);
    }

    float DistanceToGround()
    {
        // Perform a raycast downward and return the distance to the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            return hit.distance;
        }
        return Mathf.Infinity;
    }
}
