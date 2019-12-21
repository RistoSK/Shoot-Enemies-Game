using UnityEngine;

public class PoolableObject : MonoBehaviour, IPoolable
{
    public IObjectPool poolableObject { get; set; }

    public virtual void PrepareToUse()  {}

    public virtual void ReturnToPool()
    {
        poolableObject.ReturnToPool(this);
    }
}
