using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IItemManager
{

    /// <summary>
    /// Get Item need.
    /// Lay item can dung den.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    Item GetItem(string type, string id, string itemIndex);
    int GetMax(string type, string id);
    /// <summary>
    /// Get dictionary
    /// </summary>
    /// <returns></returns>
    Dictionary<string, Item> GetItemDictionary();
    void SaveItemIntoPlayerPrefX();
    void AddItem(Item item);
    List<Item> EquipmentItemList();
}
