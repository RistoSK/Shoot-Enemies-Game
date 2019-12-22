﻿using UnityEngine;

public class PlayerInput : IPlayerInput
{
    public void GetInput()
    {
        VerticalMovement = Input.GetAxis("Vertical");
        HorizontalMovement = Input.GetAxis("Horizontal");
    }

    public float VerticalMovement { get; private set; }
    
    public float HorizontalMovement { get; private set; }
}
