using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
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
    }

    private void Update() {
        HandleDash();

        animator.SetFloat("xVelocity", Mathf.Abs(rb2D.velocity.x));
        animator.SetFloat("yVelocity", rb2D.velocity.y);
    }

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
