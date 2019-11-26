using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item : BaseStat
{
    public float itemIndex;
    public float id; // identify of item
    public float type; // type of item
    public float level; // level item
    public float levelUpgrade; // color
    public bool isEquip;
    public Item(float itemIndex, float id, float type, float value, float level, float levelUpgrade, bool isEquip)
    {
        this.itemIndex = itemIndex;
        this.id = id;
        this.type = type;
        this.value = value;
        this.level = level;
        this.levelUpgrade = levelUpgrade;
        this.isEquip = isEquip;
    }
    public void SetItem(float level, float levelUpgrade, bool isEquip)
    {
        this.level = level;
        this.levelUpgrade = levelUpgrade;
        this.isEquip = isEquip;
    }
    public void SetItem(Item item)
    {
        this.itemIndex = item.itemIndex;
        this.id = item.id;
        this.type = item.type;
        this.value = item.value;
        this.level = item.level;
        this.levelUpgrade = item.levelUpgrade;
        this.isEquip = item.isEquip;
    }
    public Item(float value) {
        this.value = value;
    }
    public Item() { }


    public void AddLevel(float value)
    {
        if (value > 0)
            level += value;
    }
    public void AddLevelUpgrade(float value)
    {
        if (value > 0)
        {
            levelUpgrade += value;
        }
    }
}
