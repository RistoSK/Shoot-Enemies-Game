using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : PoolableObject, IDamageable
{
    [SerializeField] private EnemyStats[] _enemyStats;

    private readonly Vector3 _vectorLeft = new Vector3(-1, 0, 0);
    
    private EnemyStats _currentStats;
    private float _currentHealth;
    private float _enemySpeed;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        if (!_enemyStats.Any())
        {
            Debug.LogError("Enemy Stats have not been assigned");
        }
    }

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
        if (!_spriteRenderer)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        } 
        
        int index = Random.Range(0, _enemyStats.Length);
        _currentStats = _enemyStats[index];

        _spriteRenderer.color = _currentStats.Color;

        GameMode gameMode = EnemyManager.Instance.CurrentGameMode;
        
        _currentHealth = _currentStats.Health * gameMode.PercentageDifficultyMultiplier;
        _enemySpeed =  _currentStats.Speed * gameMode.PercentageDifficultyMultiplier;
    }

    private void Update()
    {
        transform.position += _vectorLeft * (_enemySpeed * Time.deltaTime);
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
