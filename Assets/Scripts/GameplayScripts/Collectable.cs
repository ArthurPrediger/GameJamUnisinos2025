using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour , IInteractables
{
    public void ActivateInteraction()
    {
        Destroy(gameObject);
    }
}
