using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;
using Types;
using Stats;
using System.Linq;
using UnityEngine.UI;
using Enemies;

public class Attributes : MonoBehaviour 
{
    public string Name = "Lorem Ipsum";
    private readonly int maxHealth = 100;
    [SerializeField]
    private int currentHealth = 100;
    public Slider healthBar; 
    private readonly int maxStamina = 80;
    [SerializeField]
    private int currentStamina = 80;
    public Slider staminaBar; 
    private bool isDead = false;
    public int attackModifier = 10;
    public int defenceModifier = 10;
    public Dictionary<StatType, Stat> stats = _stats.stats;

    #region Singleton

    #endregion

    public Attributes(string name, int maxHealth, int currentHealth, int maxStamina, int currentStamina, int attackModifier, int defenceModifier)
    {

        this.Name = name;
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
        this.maxStamina = maxStamina;
        this.currentStamina = currentStamina;
        this.attackModifier = attackModifier;
        this.defenceModifier = defenceModifier;
    }
    public void SetAttributes(Attributes attributes)
    {
        this.Name = attributes.Name;
        this.currentHealth = attributes.currentHealth;
        this.currentStamina = attributes.currentStamina;
        this.attackModifier = attributes.attackModifier;
        this.defenceModifier = attributes.defenceModifier;
    }
    public void SetName(string name)
    {
        this.name = name;
    }
    public void Add(StatType type, StatModifier modifier)
    {
        stats[type].AddModifier(modifier);
    }
    public void Remove(StatType type, StatModifier modifier)
    {
        stats[type].RemoveModifier(modifier);
    }
    public void IncreaseBase(StatType type)
    {
        stats[type].IncreaseBase();
    }
    public void DecreaseBase(StatType type)
    {
        stats[type].DecreaseBase();
    }
    public void UpdateHealth(int value)
    {
        this.currentHealth = (int)math.clamp(currentHealth + value, 0, maxHealth);
        if(this.currentHealth <= 0)
        {
            isDead = true;
            Debug.Log($"{Name} is dead!");
        }
        Debug.Log($"{currentHealth} Health Adjusted by {value}.");
    }
    public bool IsDead()
    {
        return isDead;
    }
    public void UpdateStamina(int value)
    {
        this.currentStamina = (int)math.clamp(currentStamina + value, 0, maxStamina);
        Debug.Log($"{currentStamina} Stamina Adjusted by {value}.");
    }
    public void UpdateAttackModifier(int value)
    {
        this.attackModifier = (int)math.max(0, attackModifier + value);
        Debug.Log($"{attackModifier} Attack Modifier Adjusted by {value}.");
    }
    public void UpdateDefenceModifier(int value)
    {
        this.defenceModifier = (int)math.max(0, defenceModifier + value);
        Debug.Log($"{defenceModifier} Defence Modifier Adjusted by {value}.");
    }
    public void ShowStats()
    {
        Debug.Log($"{Name}");
        for(int i = 0; i < stats.Count; ++i)
        {
        Debug.Log($"{stats.ElementAt(i).Key}: {stats.ElementAt(i).Value.value}");
        }
    }

    private void StaminaBar(int value)
    {
        staminaBar.value = value;
    }
	private void HealthBar(int value)
    {
        healthBar.value = value;
    }
}
