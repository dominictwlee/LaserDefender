using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    T prefab = null;
    [SerializeField]
    int size = 0;

    private Queue<int> freeList;
    private Dictionary<int, T> pooledObjects;

    void Awake()
    {
        freeList = new Queue<int>(size);
        pooledObjects = new Dictionary<int, T>();

        for (var i = 0; i < size; i++)
        {
            var pooledObject = Instantiate(prefab, transform);
            var id = pooledObject.GetInstanceID();
            pooledObject.gameObject.SetActive(false);
            pooledObjects.Add(id, pooledObject);
            freeList.Enqueue(id);
        }
    }

    // Returns an object from the pool. Returns null if there are no more
    // objects free in the pool.
    public T Get()
    {
        var freeCount = freeList.Count;

        if (freeCount == 0)
        {
            return null;
        }

        var id = freeList.Dequeue();
        return pooledObjects[id];
    }

    // Returns an object to the pool.
    public void ReturnObject(GameObject pooledObject)
    {
        // Reparent the pooled object to us and disable it.
        var pooledObjectTransform = pooledObject.transform;
        pooledObjectTransform.parent = transform;
        pooledObjectTransform.localPosition = Vector3.zero;
        pooledObject.gameObject.SetActive(false);
        freeList.Enqueue(pooledObject.GetInstanceID());
    }
}
