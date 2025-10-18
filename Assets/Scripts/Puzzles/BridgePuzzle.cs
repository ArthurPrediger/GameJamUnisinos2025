using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePuzzle : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] List<GameObject> bounds = new List<GameObject>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        foreach (GameObject bound in bounds)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), bound.GetComponent<Collider2D>(), true);
        }
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
