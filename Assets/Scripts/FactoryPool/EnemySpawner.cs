using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private float _spawnRatePerMinute = 10;
    [SerializeField] private bool _shouldSpawn = true;
    
    private int _currentCount;

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
        
        var targetCount = Time.time * (_spawnRatePerMinute / 60);

        while (targetCount > _currentCount)
        {
            var inst = _objectPool.GetPrefabInstance();
            inst.transform.position = new Vector3(9.5f, Random.Range(-4.5f, 4.5f), 0);

            _currentCount++; 
        }
    }
}
