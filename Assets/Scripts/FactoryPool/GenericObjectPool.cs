using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObjectPool<T> : MonoBehaviour, IObjectPool<T> where T : MonoBehaviour, IPoolable
{
    [SerializeField] private T _prefab;

    private readonly Stack<T> _reusableObjects = new Stack<T>();

    public T GetPrefabInstance()
    {
        T currentObject;

        if (_reusableObjects.Count > 0)
        {
            currentObject = _reusableObjects.Pop();
            currentObject.transform.SetParent(null);

            currentObject.gameObject.SetActive(true);
        }
        else
        {
            currentObject = Instantiate(_prefab);
        }

        currentObject.poolableObject = this;
        currentObject.PrepareToUse();

        return currentObject;
    }

    public void ReturnToPool(T currentObject)
    {
        currentObject.gameObject.SetActive(false);

        Transform currentTransform;
        
        (currentTransform = currentObject.transform).SetParent(transform);

        currentTransform.localPosition = new Vector3(0,0,0);
        currentTransform.localScale = new Vector3(1,1,1);
        currentTransform.localEulerAngles = new Vector3(1,1,1);

        _reusableObjects.Push(currentObject);
    }

    public void ReturnToPool(object currentObject)
    {
        if (currentObject is T poolableObject)
        {
            ReturnToPool(poolableObject);
        }
    }
}
