using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterStatManager : MonoBehaviour
{
    public static CharacterStatManager instance;
    public void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        SetupCurrentCharacter();
    }
    public Character curCharacter;
    public CharacterStat Dame;
    public CharacterStat Power;
    public CharacterStat HP;
    public void SetupCurrentCharacter()
    {
        Dame.RemoveAllModifiers();
        Power.RemoveAllModifiers();
        HP.RemoveAllModifiers();
        ICharacterManager characterManager = DIContainer.GetModule<ICharacterManager>();
        curCharacter = characterManager.GetCurrentCharacter();
        ITalentManager talent = DIContainer.GetModule<ITalentManager>();
        List<Talent> talentList = talent.GetAllTalent();
        foreach (Talent _talent in talentList)
        {
            _talent.AddTalent(this);
        }
        IItemManager itemEquips = DIContainer.GetModule<IItemManager>();
        List<Item> items = itemEquips.EquipmentItemList();
        foreach (Item item in items)
        {
            item.Equip(this);
        }
        // Thay doi lai base value cua hero

        Dame.BaseValue = 10 + (float)0.2 * (curCharacter.level + 1);
        Power.BaseValue = 10 + (float)0.2 * (curCharacter.level + 1);
        HP.BaseValue = 10 + (float)0.2 * (curCharacter.level + 1);

    }
    public void ResetEquipDataStat()
    {
        Dame.RemoveAllModifiers();
        Power.RemoveAllModifiers();
        HP.RemoveAllModifiers();
        ITalentManager talent = DIContainer.GetModule<ITalentManager>();
        List<Talent> talentList = talent.GetAllTalent();
        foreach (Talent _talent in talentList)
        {
            _talent.AddTalent(this);
        }
    }
}
