using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class playerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpSpeed;
    Vector2 moveDir = Vector2.zero;
    Rigidbody2D rb;
    BoxCollider2D cldr;

    //double jump
    // float jumpTimer = 0;
    bool canDoubleJump = false;
    float numJumped = 0;
    int groundMask;

    bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, cldr.bounds.extents.y + 0.1f, groundMask);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cldr = GetComponent<BoxCollider2D>();
        rb.freezeRotation = true;
        groundMask = LayerMask.GetMask("Ground");
    }

    void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        moveDir = inputDir;
    }

    void OnJump(InputValue value){
        if(numJumped == 0){
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            numJumped++;
            canDoubleJump = false;
        }
        if(numJumped == 1 && canDoubleJump){
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            numJumped++;  
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded()){
            numJumped = 0;
        }
        if(Mathf.Approximately(rb.velocity.y, 0)){
            canDoubleJump = true;
        }
        rb.velocity = new Vector2(moveDir.x * movementSpeed, rb.velocity.y);
    }

    void FixedUpdate()
    {
        
    }
}
