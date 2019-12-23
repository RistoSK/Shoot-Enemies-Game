using UnityEngine;

public class PlayerShootingInput : IPlayerShootingInput
{
    public void GetInput()
    {
        HasShot = Input.GetButtonDown("Fire1");
    }

    public bool HasShot { get; private set; }
}
