﻿using System.Collections;
using UnityEngine;

public class Obsticle_FlyingObject : MoveableObject, IInteractable
{
    public IInteractable.InteractableType InteractType
    {
        get
        {
            return interactionType;
        }
    }

    private void Update()
    {
        if (transform.position.x <= -60)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    [SerializeField] private IInteractable.InteractableType interactionType;

    //if you have a bubble shield burn it, else we end the game as usual
    public void Interact(PlayerMovement movementController = null)
    {
        //check if the buddle shield is there, if so, break both items
        if(movementController.IsUsingShield)
        {
            //end, pop sield, and die
            movementController.ToggleBubbleShield(false);
            Destroy(this);
            return;
        }
        //stops the game
        movementController.spawner.GameIsActive = false;

    }
}
