using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TalentDatabase : MonoBehaviour
{
    public static TalentDatabase instance;
    public Dictionary<string, Sprite> talentIconList;
    private void Awake()
    {
        if (instance == null) instance = this;
        Sprite[] _itemIconList = Resources.LoadAll<Sprite>("SpriteTalent");
        talentIconList = new Dictionary<string, Sprite>();
        for (int i = 0; i < _itemIconList.Length; i++)
        {
            talentIconList.Add(_itemIconList[i].name, _itemIconList[i]);
        }
    }
    public Sprite GetTalentSprite( string type)
    {
        if (talentIconList.ContainsKey(type)) return talentIconList[type];
        return null;
    }
    public Color GetBackground(float levelUpgrade)
    {
        if (levelUpgrade < 4) return Color.white;
        else if (levelUpgrade >= 4 && levelUpgrade < 8) return Color.green;
        else if (levelUpgrade >= 8 && levelUpgrade < 12) return Color.blue;
        else return Color.magenta;
    }
}
