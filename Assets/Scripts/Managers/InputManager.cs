using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Inputs inputs;
    public InputAction movement;
    
    [SerializeField]private GameObject player1, player2;

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
