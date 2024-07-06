using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dash : MonoBehaviour
{
    public static event EventHandler OnPlayerDash;
    [Header("Reference Script")]
    public CharacterStats characterStats;
    
    private Rigidbody2D rb2D;
    private bool canDash = true;
    private bool isFacingRight = true;

    private TrailRenderer trailRenderer;
    private void Start() {
        trailRenderer = GetComponent<TrailRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        characterStats = GetComponent<CharacterStats>();

        if (trailRenderer != null)
        {
            trailRenderer.emitting = false; // Ensure the trail is off initially.
        }
    }

    private void Update() {
        HandleDash();
        
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            isFacingRight = true;
        }
        else if (horizontal < 0)
        {
            isFacingRight = false;
        }
    }
    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.F) && canDash)
        {
            StartCoroutine(Dashing());
        }
    }
    
    IEnumerator Dashing()
    {
        canDash = false;

        // Luu lai thoi gian da troi qua trong qua trinh dash   
        float startTime = Time.time;

        Vector2 dashDirection = isFacingRight ? Vector2.right : Vector2.left;

        while (Time.time < startTime + characterStats.dashDuration)
        {
            rb2D.velocity = dashDirection * characterStats.dashSpeed;
            if (trailRenderer != null)
            {
                trailRenderer.emitting = true; // Ensure the trail is off initially.
            }
            yield return null;
        }

        if (trailRenderer != null)
        {
            trailRenderer.emitting = false; // Ensure the trail is off initially.
        }

        //  tốc độ của đối tượng người chơi được đặt lại thành 0, ngăn đối tượng di chuyển tiếp sau khi dash
        rb2D.velocity = Vector2.zero;

        yield return new WaitForSeconds(characterStats.dashCooldown);

        canDash = true;
    }
}
