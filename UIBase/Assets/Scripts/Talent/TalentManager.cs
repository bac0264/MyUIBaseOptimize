using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public class TalentManager : ITalentManager
{
    private Dictionary<string, Talent> talentList;

    public TalentManager()
    {
        if (PlayerPrefs.GetInt(KeySave.IS_GAME_FOR_THE_FIST, 0) == 0)
        {
            LoadForTheFirst();
        }
        else
            LoadAllTalent();
    }
    private void LoadForTheFirst()
    {
        talentList = new Dictionary<string, Talent>();
        List<string> data = new List<string>();
        foreach (TypeOfTalent.Type val in Enum.GetValues(typeof(TypeOfTalent.Type)))
        {
            Talent talent = new Talent(0, (int)val);
            talentList.Add(GetKey(talent.type.ToString(), talent.level.ToString()), talent);
            string json = JsonUtility.ToJson(talent);
            data.Add(json);
        }
        PlayerPrefsX.SetStringArray(KeySave.TALENT_LIST, data.ToArray());
    }
    private void LoadAllTalent()
    {
        talentList = new Dictionary<string, Talent>();
        string[] data = PlayerPrefsX.GetStringArray(KeySave.TALENT_LIST);
        foreach (string json in data)
        {
            try
            {
                Talent talent = JsonUtility.FromJson<Talent>(json);
                talentList.Add(GetKey(talent.type.ToString(), talent.level.ToString()), talent);
            }
            catch
            {

            }
        }
    }
    private string GetKey(string type, string level)
    {
        return ("talent_" + type + "_" + level);
    }
    public void SaveTalentIntoPlayerPrefX()
    {
        List<string> data = new List<string>();

        foreach (KeyValuePair<string, Talent> ele1 in talentList)
        {
            string json = JsonUtility.ToJson(ele1.Value);
            data.Add(json);
        }
        PlayerPrefsX.SetStringArray(KeySave.TALENT_LIST, data.ToArray());
    }
    public Talent GetTalent(string type, string level)
    {
        if (talentList.ContainsKey(GetKey(type, level)))
            return talentList[GetKey(type, level)];
        return null;
    }
    public List<Talent> GetAllTalent()
    {
        List<Talent> _talentList = new List<Talent>();
        foreach (KeyValuePair<string, Talent> ele1 in talentList)
        {
            _talentList.Add(ele1.Value);
            Debug.Log("type: " + (TypeOfTalent.Type)ele1.Value.type+" , Level: "+ele1.Value.level);
        }
        return _talentList;
    }
    public Dictionary<string, Talent> GetTalentDictionary()
    {
        return talentList;
    }
}