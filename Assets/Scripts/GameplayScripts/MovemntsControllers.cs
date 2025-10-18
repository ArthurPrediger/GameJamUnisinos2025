using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControllerData", menuName = "Scripts/Controllers")]
public class MovementsControllers : ScriptableObject
{
   public KeyCode leftInput, rightInput, jumpInput, shootInput, interactInput;
}
