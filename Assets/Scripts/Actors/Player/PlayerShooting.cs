using UnityEngine;

public class PlayerShooting
{
    private readonly IPlayerShootingInput _input;
    private readonly PlayerStats _stats;
    private readonly Transform _projectileSpawnTransform;
    private readonly ObjectPool _pool;
    private readonly GameObject _cooldownBar;
    private readonly Transform _cooldownBarTransform;
    
    private float _currentCooldown;


    public PlayerShooting(IPlayerShootingInput input, PlayerStats stats, Transform projectileSpawn, ObjectPool pool,
                          GameObject cooldownBar, Transform cooldownBarTransform)
    {
        _stats = stats;
        _projectileSpawnTransform = projectileSpawn;
        _pool = pool;
        _cooldownBar = cooldownBar;
        _cooldownBarTransform = cooldownBarTransform;
        _input = input;
        
        _currentCooldown = stats.ShootingCooldown;
    }
    
    public void Tick()
    {
        if (_currentCooldown > _stats.ShootingCooldown)
        {
            _cooldownBar.SetActive(false);
            
            if (_input.HasShot)
            {
                var instance = _pool.GetPrefabInstance();
                var projectileTransform = instance.transform;
                
                projectileTransform.position = _projectileSpawnTransform.position;
                _currentCooldown = 0f;
                _cooldownBarTransform.localScale = new Vector3(1, 1, 0);
                _cooldownBar.SetActive(true);
            } 
        }
        else
        {
            _currentCooldown += Time.deltaTime;
            _cooldownBarTransform.localScale = new Vector3(1 -  (_currentCooldown / _stats.ShootingCooldown), 1, 0);
        }
    }
}
