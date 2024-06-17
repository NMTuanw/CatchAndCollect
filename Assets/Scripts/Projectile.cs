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
        if (other.gameObject.CompareTag("Obstacle"))
        {   
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("Prob touched the Obstacle.");
        }
    }
}
