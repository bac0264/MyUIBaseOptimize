using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;
    public Dictionary<string, Sprite> itemIconList;
    public Sprite[] itemColorList;
    public Sprite spriteDefault;
    private void Awake()
    {
        if (instance == null) instance = this;
        Sprite[] _itemIconList = Resources.LoadAll<Sprite>("SpriteItem");
        itemIconList = new Dictionary<string, Sprite>();
        for (int i = 0; i < _itemIconList.Length; i++)
        {
            itemIconList.Add(_itemIconList[i].name, _itemIconList[i]);
        }
    }
    public Sprite GetItemSprite(string type, string id, string levelUpgrade)
    {
        string x = type + "_" + id + "_" + levelUpgrade;
        if (itemIconList.ContainsKey(x)) return itemIconList[x];
        return null;
    }
    public Color GetColor(float levelUpgrade)
    {
        if (levelUpgrade == 0) return Color.white;
        else if (levelUpgrade == 1) return Color.green;
        else if (levelUpgrade == 2) return Color.blue;
        else return Color.magenta;
    }
}
