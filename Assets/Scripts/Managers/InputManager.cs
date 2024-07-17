using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : NetworkBehaviour
{
    public Inputs inputs;
    public InputAction movement;
    
    private void Awake() {
        inputs = new Inputs();
        inputs.Keyboard.Enable();
    }

    private void Start() {
        movement = inputs.FindAction("Movement");
    }


    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 moveValue = movement.ReadValue<Vector2>();
        moveValue.y = 0f;
        return moveValue;
    }
}
