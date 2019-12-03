using UnityEngine;
using System.Collections;

[System.Serializable]
public class Talent
{
    public int level;
    public int type;

    public readonly float HP_AllHero = 1;
    public readonly float ATK_AllHero = 1;
    public readonly float HP_EOP = 1; // Effect of potion
    public readonly float IncreasedStandardDamagePercent = 1;
    public readonly float Dame_Resistance = 1;
    public readonly float HP_Levelup_In_Battle = 1;
    public readonly float Fire_Rate_Percent = 1;
    public readonly float CoinBonus_In_Battle_Percent = 1;

    private StatModifier mod1;
    private StatModifier mod2;
    private StatModifier mod3;
    private StatModifier mod4;
    private StatModifier mod5;
    private StatModifier mod6;
    private StatModifier mod7;
    public Talent()
    {

    }
    public Talent(int level, int type)
    {
        this.type = type;
        this.level = level;
    }
    public void AddLevel(int level)
    {
        if (level > 0) this.level += level;
    }
    public void AddTalent(CharacterStatManager c)
    {
        mod1 = new StatModifier(HP_AllHero * (level + 1), StatModType.Flat);
        mod2 = new StatModifier(ATK_AllHero * (level + 1), StatModType.Flat);
        mod3 = new StatModifier(HP_EOP * (level + 1), StatModType.Flat);
        mod4 = new StatModifier(IncreasedStandardDamagePercent * (level + 1), StatModType.PercentAdd);
        mod5 = new StatModifier(HP_Levelup_In_Battle * (level + 1), StatModType.Flat);
        mod6 = new StatModifier(Fire_Rate_Percent * (level + 1), StatModType.PercentAdd);
        mod7 = new StatModifier(CoinBonus_In_Battle_Percent * (level + 1), StatModType.PercentAdd);
        c.HP.AddModifier(mod1);
        c.Dame.AddModifier(mod2);
    }
    public void RemoveTalent(CharacterStatManager c)
    {
        c.HP.RemoveModifier(mod1);
        c.Dame.RemoveModifier(mod2);
    }
}
