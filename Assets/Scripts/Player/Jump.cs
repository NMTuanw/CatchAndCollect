using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    [Header("Ground Raycast")]
    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask GroundLayer;

    private bool isGrounded;

    private Rigidbody2D rb2D;
    private Animator animator;

    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        HandleJump();

        animator.SetFloat("xVelocity", Mathf.Abs(rb2D.velocity.x));
        animator.SetFloat("yVelocity", rb2D.velocity.y);
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
}
