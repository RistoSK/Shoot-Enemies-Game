using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float Health;
    public float Speed;
    public float ShootingCooldown;
}