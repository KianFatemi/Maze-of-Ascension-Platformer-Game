using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public static Action<float> jump;
    public static Action<float> pause;
    public static Action<Vector2> move;
    public static Action<Vector2> RotateCamera;
   
    
    ThridPersonCharacterControls actions;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance= this;
            DontDestroyOnLoad(gameObject);

            actions = new();
            actions.Enable();

        }
    }
    void OnEnable()
    {
        actions.KeyboardAndMouse.Jump.performed += InvokeJump;
        actions.KeyboardAndMouse.Jump.canceled += InvokeJump;
        actions.KeyboardAndMouse.Move.performed += InvokeMove;
        actions.KeyboardAndMouse.Move.canceled += InvokeMove;
        actions.KeyboardAndMouse.RotateCamera.performed += InvokeRotate;
        actions.KeyboardAndMouse.RotateCamera.canceled += InvokeRotate;
        actions.KeyboardAndMouse.PauseGame.performed += InvokePause;
        actions.KeyboardAndMouse.PauseGame.canceled += InvokePause;


    }
    void InvokeJump(InputAction.CallbackContext ctx)
    {
        jump?.Invoke(ctx.ReadValue<float>());
    }

    void InvokeMove(InputAction.CallbackContext ctx)
    {
        move?.Invoke(ctx.ReadValue<Vector2>());
    }
   
    void InvokeRotate(InputAction.CallbackContext ctx)
    {
       RotateCamera?.Invoke(ctx.ReadValue<Vector2>());
    }

    void InvokePause(InputAction.CallbackContext ctx)
    {
        pause?.Invoke(ctx.ReadValue<float>());
    }

     void OnDisable()
    {
        actions.KeyboardAndMouse.Jump.performed -= InvokeJump;
        actions.KeyboardAndMouse.Jump.canceled -= InvokeJump;
        actions.KeyboardAndMouse.Move.performed -= InvokeMove;
        actions.KeyboardAndMouse.Move.canceled -= InvokeMove;
        actions.KeyboardAndMouse.RotateCamera.performed -= InvokeRotate;
        actions.KeyboardAndMouse.RotateCamera.canceled -= InvokeRotate;
        actions.KeyboardAndMouse.PauseGame.performed -= InvokePause;
        actions.KeyboardAndMouse.PauseGame.canceled -= InvokePause;
    }




}
