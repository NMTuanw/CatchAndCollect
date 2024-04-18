using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Inventory playerInventory;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Header("Ground Raycast")]
    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask GroundLayer;

    [Header("Dashing")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    
    private bool isGrounded;
    private bool isDashing;

    private float dashTimeLeft = 0;

    private float lastDash = 0;

    private Rigidbody2D rb2D;
    private Animator animator;

    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

        playerInventory = new();
    }
    private void Update() {
        HandleMovement();
        HandleJump();
        HandleDash();

        animator.SetFloat("xVelocity", Math.Abs(rb2D.velocity.x));
        animator.SetFloat("yVelocity", rb2D.velocity.y);
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 horizontalVector = new Vector2(horizontal, 0) *  moveSpeed;
        rb2D.velocity = new Vector2(horizontalVector.x, rb2D.velocity.y);

        if (horizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (horizontal < 0 )
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void HandleJump()
    {
        CheckGrounded();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            animator.SetBool("IsJumping", true);
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }

    private void CheckGrounded(){
        RaycastHit2D hitGround = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, raycastDistance, GroundLayer);

        isGrounded = hitGround.collider != null;

        animator.SetBool("IsJumping", !isGrounded);
    }

    // private void HandleDash()
    // {
    //     float horizontal = Input.GetAxis("Horizontal");

    //     if (Input.GetKeyDown(KeyCode.F))
    //     {
    //         rb2D.velocity = new Vector2 (rb2D.velocity.x, 0f);
    //         rb2D.velocity += Vector2.right * dashSpeed * Mathf.Sign(horizontal);
    //     }
    // }

    private void HandleDash()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.F) && Time.time >= lastDash + dashCooldown)
        {
            isDashing = true;
            dashTimeLeft = dashDuration;
            lastDash = Time.time;
        }

        if (isDashing)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0f); // Reset vertical velocity
            rb2D.velocity += Vector2.right * dashSpeed * Mathf.Sign(moveHorizontal);
            dashTimeLeft -= Time.deltaTime;

            if (dashTimeLeft <= 0f)
            {
                isDashing = false;
            }
        }
    }
}
