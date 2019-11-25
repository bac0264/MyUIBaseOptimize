using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class EquipmentSlotList : MonoBehaviour
{
    public EquipmentSlot[] equipSlots;
    public IItemManager itemManager;
    public Action<Item> OnRightClickEvent;

    public virtual void Start()
    {
        SetupData();
        SetupEvent();
    }
    public void SetupData()
    {
        itemManager = DIContainer.GetModule<IItemManager>();
        for (int i = 0; i < equipSlots.Length; i++)
        {
            foreach (KeyValuePair<string, Item> ele1 in itemManager.GetItemDictionary())
            {
                if (i < equipSlots.Length && ele1.Value.value > 0 && ele1.Value.isEquip && (float) equipSlots[i].type.type == ele1.Value.type)
                {
                    equipSlots[i].ITEM = ele1.Value;
                    Debug.Log("type: " + ele1.Value.type + ", id: " + ele1.Value.id + " ,value: " + ele1.Value.value + ", IndexItem: " + ele1.Value.itemIndex);
                    break;
                }
            }
        }
    }
    public void SetupEvent()
    {
        foreach (EquipmentSlot slot in equipSlots)
        {
            slot.OnRightClickEvent += OnRightClickEvent;
        }
    }
    private void OnValidate()
    {
        if (equipSlots.Length == 0) equipSlots = GetComponentsInChildren<EquipmentSlot>();
    }
    public bool AddToEquip(Item item)
    {

        ItemSlot _itemSlot = GetItemSlot(item);
        if (_itemSlot == null) return false;
        _itemSlot.ITEM = item;
        return true;
    }
    public bool RemoveToUnequip(Item item)
    {
        ItemSlot _itemSlot = RemoveItemSlot(item);
        Debug.Log(_itemSlot);
        if (_itemSlot == null) return false;
        Item _item = new Item(0);
        _itemSlot.ITEM = _item;
        return true;
    }
    // Get Item Slot
    #region
    ItemSlot GetItemSlot(Item item)
    {
        foreach (EquipmentSlot itemSlot in equipSlots)
        {
            if (itemSlot.ITEM == null && item.type == (float)itemSlot.type.type)
            {
                return itemSlot;
            }
        }
        return null;
    }
    ItemSlot RemoveItemSlot(Item item)
    {
        foreach (EquipmentSlot itemSlot in equipSlots)
        {
            if (item.type == (float)itemSlot.type.type)
            {
                return itemSlot;
            }
        }
        return null;
    }


    #endregion
}
