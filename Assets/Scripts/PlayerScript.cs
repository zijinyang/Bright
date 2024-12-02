using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] GameObject hitbox;
    Vector2 moveDir = Vector2.zero;
    Rigidbody2D rb;
    CapsuleCollider2D cldr;

    //wax counter
    public int waxNum;

    //ActionTracker
    bool isActing;
    //double jump
    bool canDoubleJump = false;
    int groundMask;

    //attack
    [SerializeField] float attackCooldownValue;
    float attackCooldown;
    bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, cldr.bounds.extents.y + 0.1f, groundMask);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cldr = GetComponent<CapsuleCollider2D>();
        rb.freezeRotation = true;
        groundMask = LayerMask.GetMask("Ground");
        waxNum = 0;
        hitbox.SetActive(false);
        attackCooldown = 0f;
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
    
    void OnAttack(InputValue value){
        if(attackCooldown <= 0){
          animator.SetTrigger("Attack");   
          attackCooldown = attackCooldownValue;
        }
     }
    
    IEnumerator whitecolor() {
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer> ().color = Color.white;
    }

    public void TakeDamage(){
        Debug.Log(waxNum);
        if(waxNum >= 0){
            waxNum--;
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(whitecolor());
        }
        if(waxNum < 0){
            die();
        }
        Debug.Log(waxNum);
    }
    public void die(){
        animator.SetTrigger("Die");
    }

    public void death(){
        Debug.Log("died");
       Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Player_attack")){
            hitbox.SetActive(true);
        }else{
            hitbox.SetActive(false);
        }
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
        if(rb.velocity.x <0){
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }else{
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void FixedUpdate()
    {
       if(attackCooldown > 0){
        attackCooldown -= Time.deltaTime;
       }
    }
}
