using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb2D;
    private Animator animator;

    private bool isFacingRight = true;
    private bool isWalking;
    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontal, 0) ;
        rb2D.velocity = new Vector2(moveDirection.x *  moveSpeed, rb2D.velocity.y);
        isWalking = moveDirection != Vector2.zero;

        animator.SetBool("IsWalking", isWalking);

        if (horizontal > 0 && !isFacingRight)
        {
            Flip();
        } else if (horizontal < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
