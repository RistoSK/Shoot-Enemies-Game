using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerProjectile : PoolableObject
{
    [SerializeField] private ProjectileStats _projectileStats;
    
    private readonly Vector3 _rightVector = new Vector3(1, 0, 0);
    
    private float _startTime;

    private void Awake()
    {
        if (!_projectileStats)
        {
            Debug.LogError("Projectile Stats have not been assigned");
        }
    }

    public override void PrepareToUse()
    {
        _startTime = Time.time;
    }

    private void Update()
    {
        transform.position += _rightVector * (Time.deltaTime * _projectileStats.Speed);

        if (Time.time - _startTime > _projectileStats.TimeOutSeconds)
        {
            ReturnToPool();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.GetComponent<IDamageable>();
        
        if (target != null)
        {
            target.TakeDamage(_projectileStats.Damage);
            ReturnToPool();
        }
    }
}