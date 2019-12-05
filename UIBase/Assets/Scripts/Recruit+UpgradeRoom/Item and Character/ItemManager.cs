using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ItemManager : IItemManager
{
    private Dictionary<string, Item> itemList = new Dictionary<string, Item>();

    public ItemManager()
    {
        LoadAllItem();
    }
    /// <summary>
    /// Save all data item into PlayerPrefX (Key = KeySave.ITEM_LIST) .
    /// Luu tat ca du lieu ve item vao PlayerPrefX 
    /// </summary>
    public void SaveItemIntoPlayerPrefX()
    {
        List<string> data = new List<string>();
        List<Item> _itemList = new List<Item>();
        Debug.Log(itemList.Count);
        foreach (KeyValuePair<string, Item> ele1 in itemList)
        {
            if (ele1.Value.value > 0)
            {
                _itemList.Add(ele1.Value);
                Debug.Log(ele1.Value.isEquip);
            }
        }
        SortLocal.selectionSort(_itemList, _itemList.Count);
        for (int i = 0; i < _itemList.Count; i++)
        {
            string json = JsonUtility.ToJson(_itemList[i]);
            if (_itemList[i].value > 0)
            {
                data.Add(json);
            }
        }
        PlayerPrefsX.SetStringArray(KeySave.ITEM_LIST, data.ToArray());
    }

    public void LoadAllItem()
    {
        itemList.Clear();
        string[] data = PlayerPrefsX.GetStringArray(KeySave.ITEM_LIST);
        foreach (string json in data)
        {
            try
            {
                Item item = JsonUtility.FromJson<Item>(json);
                if (item.isEquip) Debug.Log(item.id);
                if (item.value > 0)
                {
                    itemList.Add(GetKey(item.type.ToString(), item.id.ToString(), item.itemIndex.ToString()), item);

                }
            }
            catch
            {

            }
        }
    }
    private string GetKey(string type, string id, string itemIndex)
    {
        return (type + "_" + id + "_" + itemIndex);
    }
    public Dictionary<string, Item> GetItemDictionary()
    {
        return itemList;
    }
    public Item GetItem(string type, string id, string itemIndex)
    {
        if (itemList.ContainsKey(GetKey(type, id, itemIndex)) && type.Equals(((float)TypeOfItem.Type.Other).ToString()))
            return itemList[GetKey(type, id, itemIndex)];
        else
        {
            int indexMax = GetMax(type, id);
            Item item = new Item(indexMax, float.Parse(id), float.Parse(type), 0, 0, 0, false);
            itemList.Add(GetKey(item.type.ToString(), item.id.ToString(), item.itemIndex.ToString()), item);
            return item;
        }
    }
    public int GetMax(string type, string id)
    {
        int i = -1;
        int j = 0;
        while (i == -1)
        {
            string key = GetKey(type, id, j.ToString());
            if (itemList.ContainsKey(key))
            {
                i = -1;
            }
            else
            {
                return j;
            }
            j++;
        }
        return 0;
    }
    public void AddItem(Item item)
    {
        Item _item = GetItem(item.type.ToString(), item.id.ToString(), item.itemIndex.ToString());
        if (item.type != (float)TypeOfItem.Type.Other)
        {
            _item.SetItem(item.level, item.levelUpgrade, item.isEquip);
            _item.AddValue(1);
        }
        else
        {
            _item.AddValue(item.value);
        }
    }
    public void RemoveItem(Item item)
    {
        if (itemList.ContainsKey(GetKey(item.type.ToString(), item.id.ToString(), item.itemIndex.ToString())))
        {
            itemList.Remove(GetKey(item.type.ToString(), item.id.ToString(), item.itemIndex.ToString()));
        }
    }
    public List<Item> EquipmentItemList()
    {
        List<Item> equipmentItemList = new List<Item>();
        foreach (KeyValuePair<string, Item> ele1 in itemList)
        {
            if (ele1.Value.value > 0)
            {
                if (ele1.Value.isEquip) equipmentItemList.Add(ele1.Value);
            }
        }
        return equipmentItemList;
    }
    public Item GetEquipmentWeapon()
    {
        foreach (KeyValuePair<string, Item> ele1 in itemList)
        {
            if (ele1.Value.value > 0)
            {
                if (ele1.Value.isEquip && ele1.Value.type == (float)TypeOfItem.Type.Weapon) return ele1.Value;
            }
        }
        return null;
    }
}
