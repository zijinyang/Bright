using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour // Defines a new class named playerMovement. 
                                            // Since it inherits from MonoBehaviour, it can be attached to a GameObject in Unity.
{
    [SerializeField] float boostModifier = 1.5f; // [SerializeField] attribute allows the variable to be editable from the Unity Inspector
    // [SerializeField] Animator animator;
    SpriteRenderer spriteRenderer;
    private Rigidbody2D rb = null;
    private Vector2 inputDirection = Vector2.zero;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // This allows interaction with the physics system of the GameObject.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMove(InputValue value)
    {
        var movementDir = value.Get<Vector2>(); // (0,1) = Up, (0,-1) = Down, (1,0) = Left, (-1,0) = Right
        Debug.Log(movementDir);

        rb.velocity = movementDir * boostModifier;

        inputDirection = movementDir;

        // Animation
        if (Mathf.Approximately(rb.velocity.magnitude, 0))
        {
            // animator.SetBool("running", false);
        }
        else
        {
            // animator.SetBool("running", true);
        }

        if (movementDir.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movementDir.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collsion)
    {

    }


}
