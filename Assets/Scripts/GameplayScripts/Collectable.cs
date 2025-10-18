using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using UnityEngine;

public enum PowerUpsTypes
{
    JumpBoost,
    SpeedBoost,
    ExtraLife
}

public class Collectable : MonoBehaviour , IInteractables
{
    public PowerUpsTypes type;
    public void ActivateInteraction(PlayerManager manager)
    {

        if(type == PowerUpsTypes.JumpBoost) manager.StartJumpBoosting();
        if (type == PowerUpsTypes.SpeedBoost) manager.StartSpeedBoosting();
        
        Destroy(gameObject);
    }
}
