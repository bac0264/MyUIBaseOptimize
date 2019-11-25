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
    /// <summary>
    /// them so luong item
    /// </summary>
    /// <param name="type"></param>
    /// <param name="id"></param>
    /// <param name="value"></param>
    //void AddItemValue(string type, string id, string itemIndex, float value);
    ///// <summary>
    ///// Giam so luong item
    ///// </summary>
    ///// <param name="type"></param>
    ///// <param name="id"></param>
    ///// <param name="value"></param>
    //void ReduceItemValue(string type, string id, string itemIndex, float value);
    ///// <summary>
    ///// Tang cap cho item
    ///// </summary>
    ///// <param name="type"></param>
    ///// <param name="id"></param>
    ///// <param name="value"></param>
    //void AddItemLevel(string type, string id, string itemIndex, float value);
    ///// <summary>
    ///// Giam cap cho item
    ///// </summary>
    ///// <param name="type"></param>
    ///// <param name="id"></param>
    ///// <param name="value"></param>
    //void ReduceItemLevel(string type, string id, string itemIndex, float value);
    ///// <summary>
    ///// Tang mau ( Levelupgrade = 0 <=> white, 1 <=> green, 2 <=> blue, 3 <=> violet
    ///// </summary>
    ///// <param name="type"></param>
    ///// <param name="id"></param>
    ///// <param name="value"></param>
    //void AddItemColor(string type, string id, string itemIndex, float value);
    ///// <summary>
    ///// giam mau
    ///// </summary>
    ///// <param name="type"></param>
    ///// <param name="id"></param>
    ///// <param name="value"></param>
    //void ReduceItemColor(string type, string id, string itemIndex, float value);
    ///// <summary>
    ///// Get index max
    ///// </summary>
    ///// <param name="type"></param>
    ///// <param name="id"></param>
    int GetMax(string type, string id);
    /// <summary>
    /// Get dictionary
    /// </summary>
    /// <returns></returns>
    Dictionary<string, Item> GetItemDictionary();
    void SaveItemIntoPlayerPrefX();
    void AddItem(Item item);
}
