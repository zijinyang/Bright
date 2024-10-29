using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class playerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    Vector2 moveDir = Vector2.zero;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        moveDir = inputDir;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveDir.x * movementSpeed, rb.velocity.y);
    }
}
