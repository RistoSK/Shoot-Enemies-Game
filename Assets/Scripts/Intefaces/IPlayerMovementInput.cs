using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMovementInput : IPlayerInput
{
    float VerticalMovement { get; }
    float HorizontalMovement { get; }
}
