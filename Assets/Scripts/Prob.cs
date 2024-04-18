using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prob : MonoBehaviour
{

    [SerializeField] private float droppingSpeed;
    private void Start() {

    }
    private void Update() {
        transform.Translate(Vector2.down * droppingSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            Debug.Log("Prob touched the ground.");
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Prob touched the player.");
        }
    }
}
