using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;
    public Dictionary<string, Sprite> itemIconList;
    public Dictionary<string, Sprite> itemType;
    private void Awake()
    {
        if (instance == null) instance = this;
        Sprite[] _itemIconList = Resources.LoadAll<Sprite>("SpriteItem");
        itemIconList = new Dictionary<string, Sprite>();
        itemType = new Dictionary<string, Sprite>();
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
    public Color GetBackground(float levelUpgrade)
    {
        if (levelUpgrade == 0) return Color.white;
        else if (levelUpgrade == 1) return Color.green;
        else if (levelUpgrade == 2) return Color.blue;
        else return Color.magenta;
    }
    public Color GetItemType(string type)
    {
        //string x = "_" + type + "_";
        //if (itemIconList.ContainsKey(x)) return itemIconList[x];
        //return null;
        if (type.Equals("0")) return Color.red;
        else if (type.Equals("1")) return Color.black;
        else if (type.Equals("2")) return Color.cyan;
        else if (type.Equals("3")) return Color.gray;
        else return Color.yellow;
    }
}
