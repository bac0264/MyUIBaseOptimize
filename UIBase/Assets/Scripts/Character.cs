using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    public static Character instance;
    public void Awake()
    {
        if (instance == null) instance = this;
    }
    public CharacterStat Dame;
    public CharacterStat Power;
    public CharacterStat HP;

    public void ResetEquipDataStat()
    {
        Dame.RemoveAllModifiers();
        Power.RemoveAllModifiers();
        HP.RemoveAllModifiers();
        ITalentManager talent = DIContainer.GetModule<ITalentManager>();
        List<Talent> talentList =  talent.GetAllTalent();
        foreach(Talent _talent in talentList)
        {
            _talent.AddTalent(this);
        }
    }
}
