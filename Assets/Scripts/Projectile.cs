using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int moveSpeed;
    public int projectileDamage;

    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boss"))
        {   
            Destroy(gameObject);
            BossHealthManager.instance.RemoveHealth(projectileDamage);
            Debug.Log("Prob touched the Boss.");
        }
    }
}
