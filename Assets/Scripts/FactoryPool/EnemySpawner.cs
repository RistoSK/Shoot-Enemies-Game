using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private float _spawnRatePerMinute = 10;

    private int _currentCount;

    private void Update()
    {
        var targetCount = Time.time * (_spawnRatePerMinute / 60);

        while (targetCount > _currentCount)
        {
            var inst = _objectPool.GetPrefabInstance();
            inst.transform.position = new Vector3(9.5f, Random.Range(-4.5f, 4.5f), 0);

            _currentCount++; }
    }
}
