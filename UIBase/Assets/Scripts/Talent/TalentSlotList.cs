using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class TalentSlotList : MonoBehaviour
{
    public TalentSlot[] talentSlots;
    public ITalentManager talentManager;
    public Action<Talent> OnRightClickEvent;

    public virtual void Start()
    {
        SetupData();
        SetupEvent();
    }
    public void SetupEvent()
    {
        foreach (TalentSlot slot in talentSlots)
        {
            slot.OnRightClickEvent += OnRightClickEvent;
        }
    }
    public void SetupData()
    {
        talentManager = DIContainer.GetModule<ITalentManager>();
        int i = 0;
        foreach (KeyValuePair<string, Talent> ele1 in talentManager.GetTalentDictionary())
        {

            talentSlots[i].TALENT = ele1.Value;
            i++;
            Debug.Log("type: " + (TypeOfTalent.Type)ele1.Value.type + ", level: " + (ele1.Value.level + 1));
        }
    }
    private void OnValidate()
    {
        if (talentSlots.Length == 0) talentSlots = GetComponentsInChildren<TalentSlot>();
    }

    public TalentSlot GetTalentSlot(Talent talent)
    {
        foreach (TalentSlot _talent in talentSlots)
        {
            if (_talent.TALENT != null)
                if (_talent.TALENT.type.Equals(talent.type)) return _talent;
        }
        return null;
    }
    public TalentSlot GetRandomTalentSlot()
    {
        TalentSlot talent = GetTalentSlotHavingMaxLevel();
        List<TalentSlot> talentRandomList = new List<TalentSlot>();
        for (int i = 0; i < talentSlots.Length; i++)
        {
            int distance = talent.TALENT.level - talentSlots[i].TALENT.level;
            if (distance > 2) talentRandomList.Add(talentSlots[i]);
        }
        if (talentRandomList.Count <= 0) return talent;
        int j = UnityEngine.Random.Range(0, talentRandomList.Count);
        return talentRandomList[j];
    }
    public TalentSlot GetTalentSlotHavingMaxLevel()
    {
        TalentSlot talent = talentSlots[0];
        for (int i = 0; i < talentSlots.Length; i++)
        {
            if (talentSlots[i].TALENT.level >= talent.TALENT.level) talent = talentSlots[i];
        }
        return talent;
    }
    public void AddLevelRandom()
    {
        TalentSlot talentSlot = GetRandomTalentSlot();
        if (Character.instance != null)
            talentSlot.TALENT.RemoveTalent(Character.instance);
        talentSlot.TALENT.AddLevel(1);
        if (Character.instance != null)
            talentSlot.TALENT.AddTalent(Character.instance);
        talentSlot.TALENT = talentSlot.TALENT;
        talentManager.SaveTalentIntoPlayerPrefX();
    }
}
