using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private float _spawnCooldownInSeconds;
    [SerializeField] private bool _shouldSpawn = true;
    
    private int _currentCount;
    private float _currentCooldown;

    private void Awake()
    {
        if (!_objectPool)
        {
            Debug.LogError("Enemy Object Pool has not been assigned");
        }
    }

    public void ShouldSpawn(bool shouldSpawn)
    {
        _shouldSpawn = shouldSpawn;
    }
    
    private void Update()
    {
        if (!_shouldSpawn)
        {
            return;
        }

        if (_currentCooldown > _spawnCooldownInSeconds)
        {
            var inst = _objectPool.GetPrefabInstance();
            inst.transform.position = new Vector3(9.5f, Random.Range(-4.5f, 4.5f), 0);
            _currentCooldown = 0f;
        }

        _currentCooldown += Time.deltaTime;
    }
}
