using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb2D;
    private Animator animator;

    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        HandleMovement();

        animator.SetFloat("xVelocity", Mathf.Abs(rb2D.velocity.x));
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
}
