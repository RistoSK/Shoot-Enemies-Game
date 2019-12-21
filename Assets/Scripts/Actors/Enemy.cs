using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : PoolableObject, IDamageable
{
    [SerializeField] private EnemyStats[] _enemyStats;
    
    private EnemyStats _currentStats;
    private float _currentHealth;
    
    public Rigidbody2D Rigidbody2D { get; private set; }

    private void OnEnable()
    {
        EnemyManager.Instance.OnGameFinished += ReturnToPool;
    }

    private void OnDisable()
    {
        EnemyManager.Instance.OnGameFinished -= ReturnToPool;
    }

    public override void PrepareToUse()
    {
        if (!Rigidbody2D)
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        int index = Random.Range(0, _enemyStats.Length);

        _currentStats = _enemyStats[index];

        GetComponent<SpriteRenderer>().color = _currentStats.Color;
        
        GameMode gameMode = EnemyManager.Instance.CurrentGameMode;
        _currentHealth = _currentStats.Health * gameMode.PercentageDifficultyMultiplier;
        
        float speed = _currentStats.Speed * gameMode.PercentageDifficultyMultiplier;
        
        Rigidbody2D.AddForce(new Vector2(-1, 0) * speed , ForceMode2D.Impulse);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
            
        if (_currentHealth <= 0)
        {
            EnemyManager.Instance.PointsGained(_currentStats.Points);
            ReturnToPool();
        }
    }
}
