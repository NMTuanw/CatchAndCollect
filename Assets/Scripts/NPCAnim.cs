using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnim : MonoBehaviour
{

    public Animator animator;

    public enum NPCState
    {
        Idle,
        Move
    }
    public NPCState currentState;

    [Header("NPC Random State Change Time")]
    [SerializeField] private float minStateChangeTime;
    [SerializeField] private float maxStateChangeTime;

    [Header("NPC Move Speed")]
    [SerializeField] private float npcMINMoveSpeed;
    [SerializeField] private float npcMAXMoveSpeed;


    [Header("Map Boundary")]
    [SerializeField] private float leftBoundary = 70;
    [SerializeField] private float rightBoundary = 170;

    [SerializeField] private float npcMoveSpeed;
    private int direction;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ChangeStateRandomly());
    }

    private void Update()
    {
        if (currentState == NPCState.Move)
        {
            Movement();
        }
    }
    private IEnumerator ChangeStateRandomly()
    {
        while (true)
        {
            // Wait for a random time between the specified range
            float waitTime = Random.Range(minStateChangeTime, maxStateChangeTime);
            yield return new WaitForSeconds(waitTime);

            // Randomly select between idle and move states
            currentState = (NPCState)Random.Range(0, 2);

            switch (currentState)
            {
                case NPCState.Idle:
                    animator.SetBool("IsMoving", false);
                    break;
                case NPCState.Move:
                    animator.SetBool("IsMoving", true);
                    direction = Random.Range(0, 2) == 0 ? -1 : 1;
                    npcMoveSpeed = Random.Range(npcMINMoveSpeed, npcMAXMoveSpeed);
                    break;
            }
        }
    }

    private void Movement()
    {
        if (transform.position.x < leftBoundary)
        {
            direction = 1;
        }
        else if (transform.position.x > rightBoundary)
        {
            direction = -1;
        }


        transform.Translate(Vector2.right * direction * npcMoveSpeed * Time.deltaTime);
    }
}

