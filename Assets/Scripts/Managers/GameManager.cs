using UnityEngine;
using Enemies;
using System.Numerics;
public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject warriorSkeletonPrefab;
    public GameObject archerSkeletonPrefab;
    public GameObject alienPrefab;
    private int posX;
    private int posY;
    void Awake()
    {
        EnemySpawner.RegisterPrefab(EnemyType.warriorSkeleton, warriorSkeletonPrefab);
        EnemySpawner.RegisterPrefab(EnemyType.archerSkeleton, archerSkeletonPrefab);
        EnemySpawner.RegisterPrefab(EnemyType.alien, alienPrefab);
    }
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            EnemySpawner.SpawnEnemy(EnemyType.archerSkeleton, UnityEngine.Quaternion.identity);
        }
        for(int i = 0; i < 5; i++)
        {
            EnemySpawner.SpawnEnemy(EnemyType.warriorSkeleton, UnityEngine.Quaternion.identity);
        }
        for(int i = 0; i < 10; i++)
        {
            EnemySpawner.SpawnEnemy(EnemyType.alien, UnityEngine.Quaternion.identity);
        }
        
        foreach(var temp in EnemyManager.GetAllKeys())
        {
            Debug.Log($"{temp}");
        }
    }
    
}