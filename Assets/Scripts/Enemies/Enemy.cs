using UnityEngine;
using Enemies;
using Types;
using Unity.VisualScripting;

[RequireComponent(typeof(Attributes))]
public class Enemy : MonoBehaviour
{
    public string id;
    public EnemyType enemyType;
    private DamageType damageType;
    private float factor;
    private Attributes attributes;
    public void Start()
    {
        attributes = GetComponent<Attributes>();
    }
    public Enemy(Attributes attributes)
    {
        attributes = GetComponent<Attributes>();
        Init(attributes);
    }
    public void setAttributes(Attributes attributes)
    {
        this.attributes = attributes;
    }
    public void Init()
    {
        if (attributes != null && enemyType.attributes != null)
        {
            attributes = enemyType.attributes;
            damageType = enemyType.damageType;
            factor = enemyType.factor;
        }
        else
        {
            Debug.LogError("Attributes component or enemy data is missing!");
        }
    }
    public void Init(Attributes attributes)
    {
        if (attributes != null && enemyType.attributes != null)
        {
            attributes = enemyType.attributes;
            damageType = enemyType.damageType;
            factor = enemyType.factor;
        }
        else
        {
            Debug.LogError("Attributes component or enemy data is missing!");
        }
    }
    public void OnDeath()
    {
        Debug.Log($"{enemyType} with ID {id} has died.");
        EnemyManager.UnregisterEnemy(id);
        EnemySpawner.ReturnToPool(gameObject);
    }
}