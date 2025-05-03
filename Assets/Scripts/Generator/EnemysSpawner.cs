using UnityEngine;
using Enemies;
using System.Collections.Generic;
using System.Numerics;

public static class EnemySpawner
{
    private static Dictionary<string, Queue<GameObject>> enemyPools = new Dictionary<string, Queue<GameObject>>();
    private static Dictionary<string, GameObject> enemyPrefabs = new Dictionary<string, GameObject>();
    private static Queue<string> reusableIds = new Queue<string>();
    private static int idCounter = 0;
    private static int posX = 5; 
    private static int posY = 5;
    public static void RegisterPrefab(EnemyType enemyType, GameObject prefab)
    {
        string typeKey = enemyType.attributes.Name;
        if (!enemyPrefabs.ContainsKey(typeKey))
        {
            enemyPrefabs[typeKey.ToString()] = prefab;
            enemyPools[typeKey.ToString()] = new Queue<GameObject>();
        }
    }

    private static string GenerateUniqueId()
    {
        if (reusableIds.Count > 0)
            return reusableIds.Dequeue();
        return $"Enemy_{idCounter++}";
    }
    public static GameObject SpawnEnemy(EnemyType enemyType, UnityEngine.Quaternion rotation)
    {
        string typeKey = enemyType.attributes.Name;

        if (!enemyPrefabs.ContainsKey(typeKey))
        {
            Debug.LogError($"Prefab for enemy type '{typeKey}' not registered.");
            return null;
        }

        GameObject enemyGO;
        RandomPosition();
        UnityEngine.Vector2 position = new UnityEngine.Vector2(posX, posY);

        if (enemyPools[typeKey].Count > 0)
        {
            enemyGO = enemyPools[typeKey].Dequeue();
            enemyGO.transform.position = position;
            enemyGO.transform.rotation = rotation;
            enemyGO.SetActive(true);
        }
        else
        {
            enemyGO = GameObject.Instantiate(enemyPrefabs[typeKey], position, rotation);
            // enemyGO.AddComponent<Enemy>();
            // enemyGO.AddComponent<Attributes>();
        }

        // Assign EnemyType and unique ID
        enemyGO.GetComponent<Attributes>().SetAttributes(enemyType.attributes);
        enemyGO.GetComponent<Enemy>().enemyType = enemyType;
        enemyGO.GetComponent<Enemy>().id = GenerateUniqueId();
        EnemyManager.RegisterEnemy(enemyGO.GetComponent<Enemy>());
        return enemyGO;
    }

    public static GameObject SpawnEnemy(EnemyType enemyType, UnityEngine.Vector3 position, UnityEngine.Quaternion rotation)
    {
        string typeKey = enemyType.ToString();

        if (!enemyPrefabs.ContainsKey(typeKey))
        {
            Debug.LogError($"Prefab for enemy type '{typeKey}' not registered.");
            return null;
        }

        GameObject enemyGO;

        if (enemyPools[typeKey].Count > 0)
        {
            enemyGO = enemyPools[typeKey].Dequeue();
            enemyGO.transform.position = position;
            enemyGO.transform.rotation = rotation;
            enemyGO.SetActive(true);
        }
        else
        {
            enemyGO = GameObject.Instantiate(enemyPrefabs[typeKey], position, rotation);
        }

        // Assign EnemyType and unique ID
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.enemyType = enemyType;
        enemy.id = GenerateUniqueId();
        enemy.setAttributes(enemyType.attributes);

        return enemyGO;
    }

    public static GameObject SpawnRandomEnemy(UnityEngine.Vector3 position, UnityEngine.Quaternion rotation)
    {
        List<EnemyType> list = EnemyType.enemyList;
        int index = UnityEngine.Random.Range(0, list.Count);
        return SpawnEnemy(list[index], position, rotation);
    }

    public static void ReturnToPool(GameObject enemyGO)
    {
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        if (enemy == null)
        {
            GameObject.Destroy(enemyGO);
            return;
        }

        string typeKey = enemy.enemyType.attributes.name;

        if (!enemyPools.ContainsKey(typeKey))
        {
            GameObject.Destroy(enemyGO);
            return;
        }

        reusableIds.Enqueue(enemy.id); // Store this ID for reuse
        enemyGO.SetActive(false);
        enemyPools[typeKey].Enqueue(enemyGO);
    }
    public static void RandomPosition()
    {
        do
        {
            posX = UnityEngine.Random.Range(-10, 11);
            posY = UnityEngine.Random.Range(-10, 11);
        }while(Mathf.Abs(posX) < 5 || Mathf.Abs(posY) < 5);
        // foreach(GameObject gameObject in enemyPools.Values)
    }
}
