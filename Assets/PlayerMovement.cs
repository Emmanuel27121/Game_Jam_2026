using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float movementSpeed = 5f;
    bool isFacingRight = true;
    float jumpPower = 4f;
    bool isGrounded = true;

    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //rb.velocity = new Vector2(rb.velocity.y, jumpPower);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
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
}
