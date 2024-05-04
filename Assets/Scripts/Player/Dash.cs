using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("Dashing")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;

    public float DashCooldown { get; set;}
    
    
    private bool isDashing = false;
    private bool canDash = true;

    private Rigidbody2D rb2D;

    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        DashCooldown = dashCooldown;
    }

    private void Update() {
        HandleDash();
        //Debug.Log(DashDuration); 

    }

    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.F) && canDash && !isDashing)
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

        while (Time.time < startTime + dashDuration)
        {
            rb2D.velocity = transform.right * dashSpeed;
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
