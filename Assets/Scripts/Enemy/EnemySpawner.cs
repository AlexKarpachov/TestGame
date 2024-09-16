using System.Collections;
using UnityEngine;
using static ObjectPool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] ObjectPool pool;
    [SerializeField] string enemyName = "small enemy";
    [SerializeField] float timeBetweenEnemies = 1f;
    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] int startEnemyCount = 1;

    int currentWave = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            currentWave++;
            int enemiesInWave = startEnemyCount + currentWave -1;

            for (int i = 0; i < enemiesInWave; i++)
            {
                SpawnEnemy(enemyName);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
    public void SpawnEnemy(string name)
    {
        if (pool.poolDictionary.ContainsKey(name))
        {
            if (pool.poolDictionary[name].Count > 0)
            {
                GameObject objectToSpawn = pool.poolDictionary[name].Dequeue();
                objectToSpawn.SetActive(true);
                objectToSpawn.transform.rotation = Quaternion.identity;
            }
            else
            {
                Pool poolSettings = pool.pools.Find(p => p.name == name);
                if (poolSettings != null)
                {
                    pool.AddToPool(name, poolSettings.enemyPrefab, 1);
                    SpawnEnemy(name);
                }
            }
        }
        else
        {
            Debug.LogWarning($"Pool with name {name} does not exist.");
        }
    }

}
