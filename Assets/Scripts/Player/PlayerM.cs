using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Services.Authentication;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerM : NetworkBehaviour
{
    private Rigidbody2D rb;

    [HideInInspector]public bool isWalking; 
    public float speed = 0;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if(!IsOwner) return;
        //Debug.Log("PlayerID");
        HandlePlayerMovment();
    }
    
    public void HandlePlayerMovment()
    {
        Vector2 InputVector = GetComponent<InputManager>().GetMovementVectorNormalized();
        isWalking = InputVector != Vector2.zero;
        rb.velocity = InputVector * speed * Time.deltaTime;
    }
}
