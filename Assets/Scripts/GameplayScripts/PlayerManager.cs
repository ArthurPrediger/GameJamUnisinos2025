using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Werewolf werewolf;
    private PlayerMovement movement;

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
}
