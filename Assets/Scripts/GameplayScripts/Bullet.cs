using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 bulletDirection;
    [SerializeField] private float bulletSpeed = 20.0f;
    [SerializeField] private float bulletLifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject,bulletLifeTime);
    }
    private void FixedUpdate()
    {
        transform.position += bulletDirection * bulletSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        { 
            // The damage is calculated here
            collision.gameObject.GetComponent<PlayerMovement>(); 
        }
          
        Destroy(gameObject);
    }
}
