using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerM : MonoBehaviour
{
    [SerializeField]private GameObject inputManager;
    private Rigidbody2D rb;

    [HideInInspector]public bool isWalking; 
    public float speed = 0;

    private void Start() {
        inputManager = GameObject.FindGameObjectWithTag("GameController");
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        HandlePlayerMovment();
    }
    
    public void HandlePlayerMovment()
    {
        Vector2 InputVector = inputManager.GetComponent<InputManager>().GetMovementVectorNormalized();
        isWalking = InputVector != Vector2.zero;
        rb.velocity = InputVector * speed * Time.deltaTime;
    }

}
