using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerShootingInput : IPlayerInput
{
    bool HasShot { get; }
}
