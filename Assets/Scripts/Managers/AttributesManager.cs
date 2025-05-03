using System.Collections.Generic;
using TMPro;
using Types;
using UnityEngine;

public class AttributeManager : MonoBehaviour {

	#region Singleton

	public static AttributeManager instance;
    public Attributes attributes; //On the inspector, assign the characters' attributes.
    //In order to: STR -> DEX -> CON -> LUCK -> DEFAULT
    public List<GameObject> textList; //On the inspector, assign objects that have textmeshprogui component, where the attributes will be displayed.
 	void Awake ()
	{
		instance = this;
        // UpdateTexts();
	}

	#endregion
	public void UpdateTexts()
	{
        int index = 0;
        //In order to: STR -> DEX -> CON -> LUCK -> DEFAULT
        foreach(Stat stat in attributes.stats.Values)
		{
            textList[index++].GetComponent<TextMeshProUGUI>().text = stat.value.ToString();
		}
	}
    public void SetName(string name)
    {
        attributes.SetName(name);
    }
    public void AddStatModifier(StatType type, StatModifier modifier)
    {
        attributes.Add(type, modifier);
    }
    public void RemoveStatModifier(StatType type, StatModifier modifier)
    {
        attributes.Remove(type, modifier);
    }
    public void IncreaseBaseStat(StatType type)
    {
        attributes.IncreaseBase(type);
    }
    public void DecreaseBaseStat(StatType type)
    {
        attributes.DecreaseBase(type);
    }
    public bool UpdateHealth(int value)
    {
        attributes.UpdateHealth(value);
        return attributes.IsDead();
    }
    public void UpdateStamina(int value)
    {
        attributes.UpdateStamina(value);
    }
    public void UpdateAttack(int value)
    {
        attributes.UpdateAttackModifier(value);
    }
    public void UpdateDefence(int value)
    {
        attributes.UpdateDefenceModifier(value);
    }
}
