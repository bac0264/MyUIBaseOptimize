using UnityEngine;
using System.Collections;

public class TypeOfTalent : MonoBehaviour
{
    public enum Type
    {
        HP_AllHero,
        ATK_AllHero,
        HP_EOP, // Effect of potion
        IncreasedStandardDamagePercent,
        Dame_Resistance,
        HP_Levelup_In_Battle,
        Fire_Rate_Percent,
        CoinBonus_In_Battle_Percent,
    }
}

