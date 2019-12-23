using UnityEngine;

public class PlayerMovementInput : IPlayerMovementInput
{
    public void GetInput()
    {
        VerticalMovement = Input.GetAxis("Vertical");
        HorizontalMovement = Input.GetAxis("Horizontal");
    }
    
    public float VerticalMovement { get; private set; }
    
    public float HorizontalMovement { get; private set; }
}
