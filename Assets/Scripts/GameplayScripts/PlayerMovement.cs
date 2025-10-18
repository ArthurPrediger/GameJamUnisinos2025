using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rig;
    private bool isJumping = false;
    private bool isShooting = false;
    public MovementsControllers controllers;
    private Vector3 direction = Vector3.right;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float shootingTime = 1f;

    private Animator animator;

    private IInteractables itemInRange;

    void Start()
    {
        animator = GetComponent<Animator>();
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
            animator.SetBool("IsWalking", true);
            transform.localScale = new Vector3(-3, transform.localScale.y, transform.localScale.z);

        }
        else if (Input.GetKey(controllers.rightInput))
        {
            movementX = +1;
            direction = Vector3.right;
            animator.SetBool("IsWalking", true);
            transform.localScale = new Vector3(3, transform.localScale.y, transform.localScale.z);

        }
        else if (Input.GetKey(controllers.rightInput) && Input.GetKey(controllers.leftInput))
        {
            movementX = 0;
            animator.SetBool("IsWalking", false);
        }
        else
        {
            movementX = 0;
            animator.SetBool("IsWalking", false);
        }
        movementX = movementX * speed * Time.deltaTime;
        transform.position += new Vector3(movementX, 0, 0);
    }

    void Jump()
    {

        if (Input.GetKeyDown(controllers.jumpInput) && !isJumping)
        {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("IsJumping", true);
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
            itemInRange.ActivateInteraction(GetComponent<PlayerManager>());
        }
    }

        
    IEnumerator OnShootingTime()
    {
        animator.SetTrigger("IsShooting");
        yield return new WaitForSeconds(shootingTime);
        isShooting = false;
    }
     private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.layer == 6)
            {
                isJumping = false;
            animator.SetBool("IsJumping", false);
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
