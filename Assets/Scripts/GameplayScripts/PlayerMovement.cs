using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    private Rigidbody2D rig;
    private bool isJumping = false;
    private bool isShooting = false;
    public MovementsControllers controllers;
    private Vector3 direction = Vector3.right;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float shootingTime = 1f;

    private IInteractables itemInRange;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Shoot();
        Interact();
    }
    private void FixedUpdate()
    {
        
        if (!isShooting) Movement();
    }

    void Movement()
    { 
        //horizontal movement
         float movementX;
        if (Input.GetKey(controllers.leftInput))
        {
            movementX = -1;
            direction = Vector3.left;

        }
        else if (Input.GetKey(controllers.rightInput))
        {
            movementX = +1;
            direction = Vector3.right;

        }
        else if (Input.GetKey(controllers.rightInput) && Input.GetKey(controllers.leftInput)) movementX = 0;
        else movementX = 0;

        movementX = movementX * speed * Time.deltaTime;
        transform.position += new Vector3(movementX, 0, 0);
    }

    void Jump()
    {

        if (Input.GetKeyDown(controllers.jumpInput) && !isJumping)
        {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

    }

    void Shoot()
    {
        if (Input.GetKeyDown(controllers.shootInput) && !isJumping && !isShooting)
        {
            isShooting = true;
            Instantiate(bulletPrefab, bulletSpawn.position + direction, bulletSpawn.rotation).GetComponent<Bullet>().bulletDirection = direction;
            StartCoroutine(OnShootingTime());
        }
    }

    void Interact()
    {
        if(itemInRange != null && Input.GetKeyDown(controllers.interactInput))
        {
            itemInRange.ActivateInteraction();
        }
    }

        
    IEnumerator OnShootingTime()
    {
        yield return new WaitForSeconds(shootingTime);
        isShooting = false;
    }
     private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.layer == 6)
            {
                isJumping = false;
            }
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            itemInRange = collision.gameObject.GetComponent<IInteractables>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractables>() == itemInRange)
        {
            itemInRange = null;
        }
    }

}
