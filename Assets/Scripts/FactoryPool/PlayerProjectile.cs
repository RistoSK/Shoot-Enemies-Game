using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerProjectile : PoolableObject
{
    [SerializeField] private ProjectileStats _projectileStats;
    
    private float _startTime;

    public Rigidbody2D Rigidbody2D { get; private set; }

    // Can you add the movement here?
    public override void PrepareToUse()
    {
        _startTime = Time.time;

        if (!Rigidbody2D)
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
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