using UnityEngine;
using System.Collections;

[System.Serializable]
public class Talent 
{
    public int level;
    public int type;

    public float HP_AllHero;
    public float ATK_AllHero;
    public float HP_EOP; // Effect of potion
    public float IncreasedStandardDamagePercent;
    public float Dame_Resistance;
    public float HP_Levelup_In_Battle;
    public float Fire_Rate_Percent;
    public float CoinBonus_In_Battle_Percent;

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
    public void AddTalent(CharacterAction c)
    {
        mod1 = new StatModifier(HP_AllHero, StatModType.Flat);
        mod2 = new StatModifier(ATK_AllHero, StatModType.Flat);
        mod3 = new StatModifier(HP_EOP, StatModType.Flat);
        mod4 = new StatModifier(IncreasedStandardDamagePercent, StatModType.PercentAdd);
        mod5 = new StatModifier(HP_Levelup_In_Battle, StatModType.Flat);
        mod6 = new StatModifier(Fire_Rate_Percent, StatModType.PercentAdd);
        mod7 = new StatModifier(CoinBonus_In_Battle_Percent, StatModType.PercentAdd);
        c.HP.AddModifier(mod1);
        c.Dame.AddModifier(mod2);
    }
    public void RemoveTalent(CharacterAction c)
    {
        c.HP.RemoveModifier(mod1);
        c.Dame.RemoveModifier(mod2);
    }
}
