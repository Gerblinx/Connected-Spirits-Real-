using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public InputAction PlayerControls;

    Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
        PlayerControls.Enable();
    }

    private void OnDisable()
    {
        PlayerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
        moveDirection = PlayerControls.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }



}
