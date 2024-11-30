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

    //wax counter
    public int waxNum;

    //double jump
    // float jumpTimer = 0;
    bool canDoubleJump = false;
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
        waxNum = 0;
    }

    void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        moveDir = inputDir;
    }

    void OnJump(InputValue value){
        if(isGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        if(!isGrounded() && canDoubleJump){
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            canDoubleJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded()){
            canDoubleJump = true;
        }
        if(waxNum < 1){
            canDoubleJump = false;
        }
        if(Mathf.Approximately(rb.velocity.y, 0) && waxNum > 1){
            canDoubleJump = true;
        }
        rb.velocity = new Vector2(moveDir.x * movementSpeed, rb.velocity.y);
    }

    void FixedUpdate()
    {
        
    }
}
