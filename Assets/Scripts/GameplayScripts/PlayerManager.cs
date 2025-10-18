using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Werewolf werewolf;
    private PlayerMovement movement;
    [SerializeField] float speedBoost = 10f;
    [SerializeField] float speedBoostTime = 5f;
    [SerializeField] float jumpBoost = 10f;
    [SerializeField] float jumpBoostTime = 5f;

    private void Start()
    {
        werewolf = GetComponent<Werewolf>();
        movement = GetComponent<PlayerMovement>();
        ChangePlayerState(false);
    }
  
    public void ChangePlayerState(bool needToTransforming)
    {
        if (needToTransforming)
        {
            werewolf.enabled = true;
            movement.enabled = false;
        }
        else
        {
            werewolf.enabled = false;
            movement.enabled = true;
        }
    }

    public void StartSpeedBoosting()
    {
        StartCoroutine(OnSpeedBoost());
    }
    public void StartJumpBoosting()
    {
        StartCoroutine(OnJumpBoost());
    }
   IEnumerator OnSpeedBoost()
    {
        float defaultSpeed = movement.speed;
        movement.speed += 10; 

        yield return new WaitForSeconds(speedBoostTime);
        movement.speed = defaultSpeed;
    }
     IEnumerator OnJumpBoost()
    {
        float defaultJump = movement.jumpForce;
        movement.jumpForce += 10; 

        yield return new WaitForSeconds(jumpBoostTime);
        movement.jumpForce = defaultJump;
    }
      
}
