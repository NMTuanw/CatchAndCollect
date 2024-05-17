using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dash : MonoBehaviour
{
    [Header("Dashing")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;

    public float DashCooldown { get; set;}
    
    private Rigidbody2D rb2D;

    private bool isDashing = false;
    private bool canDash = true;

    private bool isFacingRight = true;


    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        DashCooldown = dashCooldown;
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
        isDashing = true;
        canDash = false;

        // Luu lai thoi gian da troi qua trong qua trinh dash   
        float startTime = Time.time;

        Vector2 dashDirection = isFacingRight ? Vector2.right : Vector2.left;

        while (Time.time < startTime + dashDuration)
        {
            rb2D.velocity = dashDirection * dashSpeed;
            yield return null;
        }

        //  tốc độ của đối tượng người chơi được đặt lại thành 0, ngăn đối tượng di chuyển tiếp sau khi dash
        rb2D.velocity = Vector2.zero;

        // Đảm bảo isDashing được đặt lại thành false khi hành động kết thúc
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
