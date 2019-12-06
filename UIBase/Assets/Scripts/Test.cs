using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour
{

    private void Awake()
    {
        IItemManager item = DIContainer.GetModule<IItemManager>();
        List<Item> itemList = item.EquipmentItemList();
        foreach(Item _item in itemList)
        {
            Debug.Log("Type: " + (TypeOfItem.Type)_item.type + " ,id: " + _item.id + ", level: " + _item.level + " ,LevelUpgrade: " + _item.levelUpgrade);
        }
    }
}
