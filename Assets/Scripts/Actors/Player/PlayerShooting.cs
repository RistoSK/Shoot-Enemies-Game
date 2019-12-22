using UnityEngine;

public class PlayerShooting
{
    private readonly PlayerStats _playerStats;
    private readonly Transform _projectileSpawnTransform;
    private readonly ObjectPool _objectPool;
    private readonly GameObject _cooldownBar;
    private readonly Transform _cooldownBarTransform;
    
    private float _currentCooldown;


    public PlayerShooting(PlayerStats stats, Transform projectileSpawn, ObjectPool objectPool,
        GameObject cooldownBar, Transform cooldownBarTransform)
    {
        _playerStats = stats;
        _projectileSpawnTransform = projectileSpawn;
        _objectPool = objectPool;
        _cooldownBar = cooldownBar;
        _cooldownBarTransform = cooldownBarTransform;

        _currentCooldown = stats.ShootingCooldown;
    }
    
    public void Tick()
    {
        if (_currentCooldown > _playerStats.ShootingCooldown)
        {
            _cooldownBar.SetActive(false);
            
            if (Input.GetButtonDown("Fire1"))
            {
                var instance = _objectPool.GetPrefabInstance();
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
            _cooldownBarTransform.localScale = new Vector3(1 -  (_currentCooldown / _playerStats.ShootingCooldown), 1, 0);
        }
    }
}
