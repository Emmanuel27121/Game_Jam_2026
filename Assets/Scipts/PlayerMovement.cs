using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float movementSpeed = 5f;
    bool isFacingRight = true;
    float jumpPower = 7f;
    bool isGrounded = true;
    public Camera obj;
    Rigidbody2D rb;
    Animator animator;
    public static InputSystem_Actions playerControl;
    SpriteRenderer spRender;
    bool powerActivated;
    public Image button;

    private void Awake()
    {
        playerControl = new InputSystem_Actions();
        spRender = GetComponent<SpriteRenderer>();
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
        else if (playerControl.Player.Reset.triggered)
        {
            StopAllCoroutines();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (playerControl.Player.Interact.triggered)
        {
            switchCharacter();
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);

        if (playerControl.Player.Power.triggered)
        {
            powers(gameObject.transform.parent);
        }
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            bool flip = spRender.flipX;
            isFacingRight = !isFacingRight;
            //Vector3 localScale = transform.localScale;
            spRender.flipX = !flip;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.GetType());
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

    void switchCharacter()
    {
        int currentObj = gameObject.transform.GetSiblingIndex();
        Transform currPlayerPosition = gameObject.transform;
        Transform parent = gameObject.transform.parent;
        int nextObj = currentObj + 1;
        if(nextObj == 3)
        {
            nextObj = 0;
        }
        Transform nextCharacte = parent.transform.GetChild(nextObj);
        nextCharacte.position = currPlayerPosition.position;
        nextCharacte.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }


    void powers(Transform parent)
    {
        int curr = gameObject.transform.GetSiblingIndex();
        
        if (gameObject.transform.GetSiblingIndex() == 0)
        {
            Debug.Log("Correct PLayer");
            MovePlatformY.freez = true;
        }

        if(gameObject.transform.GetSiblingIndex() == 1 )
        {

            if (powerActivated == false)
            {
                powerActivated = true;
                jumpPower = 12f;
                Debug.Log(jumpPower);
                button.gameObject.GetComponent<OnScreenButton>().enabled = false;
                button.gameObject.GetComponent<Image>().color = Color.black;
                StartCoroutine(EnableAndDisableButton());
            }
            
        }
    }


    IEnumerator EnableAndDisableButton()
    {
        yield return new WaitForSeconds(3f);
        button.gameObject.GetComponent<OnScreenButton>().enabled = true;
        button.gameObject.GetComponent<Image>().color = Color.white;
        jumpPower = 7f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            int currScene = SceneManager.GetActiveScene().buildIndex + 1;
            Debug.Log(currScene);
            if(currScene == 4)
            {
                currScene = 0;
            }
            StopAllCoroutines();

            SceneManager.LoadScene(currScene);

        }
    }

}
