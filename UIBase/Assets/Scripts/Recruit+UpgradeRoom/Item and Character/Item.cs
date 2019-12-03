using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
    public float value;
    public float itemIndex;
    public float id; // identify of item
    public float type; // type of item
    public float level; // level item
    public float levelUpgrade; // color
    public bool isEquip; // duoc trang bi vao hero
    public bool isForgingUpgrade; // duoc chon vao upgradeSlot
    public float VALUE
    {
        set
        {
            this.value = value;
            if (this.value == 0)
            {
                IItemManager itemManager = DIContainer.GetModule<IItemManager>();
                itemManager.RemoveItem(this);
            }
        }
        get
        {
            return this.value;
        }
    }
    public readonly float dame = 10;
    public readonly float power = 5;
    public readonly float hp = 100;
    private StatModifier mod1;
    private StatModifier mod2;
    private StatModifier mod3;
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
    public Item(float itemIndex, float id, float type, float value, float level, float levelUpgrade, bool isEquip, bool isForgingUpgrade)
    {
        this.itemIndex = itemIndex;
        this.id = id;
        this.type = type;
        this.value = value;
        this.level = level;
        this.levelUpgrade = levelUpgrade;
        this.isEquip = isEquip;
        this.isForgingUpgrade = isForgingUpgrade;
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
    public Item(float value)
    {
        this.value = value;
    }
    public Item() { }
    public void AddValue(float value)
    {
        if (value > 0)
            this.value += value;
    }
    public void ReduceValue(float value)
    {
        if (value > 0)
        {
            this.value -= value;
            if (this.value < 0) this.value = 0;
        }
    }
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
            if (levelUpgrade > KeySave.MAX_LEVELUPGRADE_ITEM) levelUpgrade = KeySave.MAX_LEVELUPGRADE_ITEM;
        }
    }
    public void Equip(EquipmentPanel c)
    {
        mod1 = new StatModifier(dame, StatModType.Flat);
        mod2 = new StatModifier(hp, StatModType.Flat);
        mod3 = new StatModifier(power, StatModType.Flat);
        c.character.Dame.AddModifier(mod1);
        c.character.HP.AddModifier(mod2);
        c.character.Power.AddModifier(mod3);
    }
    public void Unequip(EquipmentPanel c)
    {
        c.character.Dame.RemoveModifier(mod1);
        c.character.HP.RemoveModifier(mod2);
        c.character.Power.RemoveModifier(mod3);
    }
}
