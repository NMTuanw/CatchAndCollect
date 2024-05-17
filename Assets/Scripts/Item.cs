using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Item : MonoBehaviour
{
    const string HEALTH_MANAGER = "HealthManager";
    [SerializeField] private float droppingSpeed;

    [SerializeField] public string itemName;

    [SerializeField] public Sprite itemIcon;

    [SerializeField] public int quantity;

    [TextArea]
    [SerializeField] public string itemDescription;

    private HealthManager healthManager;

    private void Start() {
    //    healthManager = GameObject.Find(HEALTH_MANAGER).GetComponent<HealthManager>();
    }
    private void Update() {
        transform.Translate(Vector2.down * droppingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            HealthManager.instance.RemoveHealth(1);
            Debug.Log("Prob touched the ground.");
        }

        if (other.gameObject.CompareTag("Player"))
        {   
            Destroy(gameObject);
            Debug.Log("Prob touched the player.");
        }
    }
}
