using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var poolable = other.GetComponent<PoolableObject>();
        
        if (poolable)
        {
            poolable.ReturnToPool();
        }
    }
}
