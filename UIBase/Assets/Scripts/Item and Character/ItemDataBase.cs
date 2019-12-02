﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;
    public Dictionary<string, Sprite> itemIconList;
    public Sprite[] backgroundList;
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
    public Sprite GetBackground(float levelUpgrade)
    {
        Sprite sprite = backgroundList[(int)levelUpgrade];
        if (sprite != null)
            return sprite;
        return null;
    }
}
