using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float movementSpeed = 5f;
    bool isFacingRight = true;
    float jumpPower = 4f;
    bool isGrounded = true;

    Rigidbody2D rb;
    Animator animator;
    InputSystem_Actions playerControl;


    private void Awake()
    {
        playerControl = new InputSystem_Actions();
        playerControl.Enable();

;    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()


    {
        horizontalInput = playerControl.Player.Move.ReadValue<Vector2>().x;


        FlipSprite();

        if (playerControl.Player.Jump.triggered && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.GetType());
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }

    private void Jump()
    {
        //rb.velocity = new Vector2(rb.velocity.y, jumpPower);
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        isGrounded = false;
        animator.SetBool("isJumping", !isGrounded);
    }
}
