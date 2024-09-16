using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string name;
        public GameObject enemyPrefab;
        public int size;
    }

    [SerializeField] Transform startingPos;

    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        PoolFilling();
    }

    void PoolFilling()
    {
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.enemyPrefab);
                obj.SetActive(false);
                obj.transform.position = startingPos.position;
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.name, objectPool);
        }
    }

    public void ReturnToPool(string poolName, GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = startingPos.position;

        poolDictionary[poolName].Enqueue(obj);
    }

    public void AddToPool(string poolName, GameObject prefab, int count = 1)
    {
        if (!poolDictionary.ContainsKey(poolName))
        {
            Debug.LogWarning($"Pool with name {poolName} does not exist.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            obj.transform.position = startingPos.position;
            poolDictionary[poolName].Enqueue(obj);
        }
    }
}
