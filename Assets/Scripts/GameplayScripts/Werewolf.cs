using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Werewolf : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    //private NavMeshAgent agent;
    private Rigidbody2D rb;
    private Collider2D collider;
    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private float jumpForce = 2f;
    [SerializeField]
    private float playerDistAttack = 2.0f;
    private bool canJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = (player.transform.position - transform.position);

        if(targetDir.magnitude > playerDistAttack)
        {
            ChasePlayer(targetDir);
        }
        else
        {

        }
    }

    private void FixedUpdate()
    {
    }

    private void ChasePlayer(Vector3 targetDir)
    {
        transform.position += Vector3.right * Mathf.Sign(targetDir.x) * speed * Time.deltaTime;

        if (targetDir.x == 0f) return;

        if (canJump)
        {
            Vector2 rayOrigin = transform.position + Vector3.right * Mathf.Sign(targetDir.y) * (collider.bounds.extents.x + 0.0001f);
            Vector2 rayDir = Vector2.right * Mathf.Sign(targetDir.x) * 2f;
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDir);
            if (hit.collider && hit.collider.CompareTag("Ground") && hit.distance < 1.0f)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                canJump = false;
            }
            Debug.DrawRay(rayOrigin, rayDir, Color.red);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
            canJump = true;
    }
}
