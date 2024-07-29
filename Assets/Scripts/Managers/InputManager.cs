using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : NetworkBehaviour
{
    public Inputs inputs;
    public InputAction movement, stancesInput;
    private AttackPaterns attackPaterns;
    private void Awake() {
        inputs = new Inputs();
        inputs.Keyboard.Enable();
    }

    private void Start() {
        movement = inputs.FindAction("Movement");
        stancesInput = inputs.FindAction("Stances");
        stancesInput.performed += ChangeStances;
        attackPaterns = gameObject.GetComponent<AttackPaterns>();
    }

    private void OnEnable() {
        stancesInput.Enable();
    }

    private void OnDisable() {
        stancesInput.Disable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 moveValue = movement.ReadValue<Vector2>();
        moveValue.y = 0f;
        return moveValue;
    }

    public void ChangeStances(InputAction.CallbackContext callbackContext)
    {
        var control = callbackContext.control;
        if (stancesInput.IsPressed())
        {
            if (control.name == stancesInput.bindings[0].path.Split('/')[^1])
            {
                attackPaterns.ChangeStance(0);
            }
            else if (control.name == stancesInput.bindings[1].path.Split('/')[^1])
            {
                attackPaterns.ChangeStance(1);
            }
            else if (control.name == stancesInput.bindings[2].path.Split('/')[^1])
            {
                attackPaterns.ChangeStance(2);
            }
            else if (control.name == stancesInput.bindings[3].path.Split('/')[^1])
            {
                attackPaterns.ChangeStance(3);
            }
            else
            {
                Debug.Log($"Other control pressed: {control.name}");
            }
        }
        
    }
}
