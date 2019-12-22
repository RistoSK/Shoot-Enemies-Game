using UnityEngine;

[CreateAssetMenu(menuName = "EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public int Points;
    public float Health;
    public float Speed;
    public Color Color;
}
