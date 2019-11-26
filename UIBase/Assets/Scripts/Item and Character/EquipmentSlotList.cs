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
        List<Item> item = itemManager.EquipmentItemList();
        for (int i = 0; i < equipSlots.Length; i++)
        {
            for (int j = 0; j < item.Count; j++)
            {
                if ((float)equipSlots[i].type.type == item[j].type)
                {
                    equipSlots[i].ITEM = item[j];
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
        if (_itemSlot.ITEM == null)
        {
            if (_itemSlot == null) return false;
            _itemSlot.ITEM = item;
            return true;
        }
        else
        {
            if(CharacterAction.instance != null)
            {
                if (CharacterAction.instance.itemSlotList.AddToUnequip(_itemSlot.ITEM))
                {
                    _itemSlot.ITEM = item;
                    return true;
                }

            }
            return false;
        }
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
            if (item.type == (float)itemSlot.type.type)
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
