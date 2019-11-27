using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ItemSlotList : MonoBehaviour
{
    public ItemSlot[] itemSlots;
    public IItemManager itemManager;
    public Action<Item> OnRightClickEvent;

    public virtual void Start()
    {
        SetupData();
    }
    public void SetupEvent()
    {
        foreach (ItemSlot slot in itemSlots)
        {
            slot.OnRightClickEvent += OnRightClickEvent;
        }
    }
    public void RemoveEvent()
    {
        foreach (ItemSlot slot in itemSlots)
        {
            slot.OnRightClickEvent -= OnRightClickEvent;
        }
    }
    public void SetupData()
    {
        itemManager = DIContainer.GetModule<IItemManager>();
        int i = 0;
        foreach (KeyValuePair<string, Item> ele1 in itemManager.GetItemDictionary())
        {
            if (i < itemSlots.Length && ele1.Value.value > 0)
            {
                itemSlots[i].ITEM = ele1.Value;
                Debug.Log("type: " + ele1.Value.type + ", id: " + ele1.Value.id + " ,value: " + ele1.Value.value
                    + ", IndexItem: " + ele1.Value.itemIndex + ", isEquip: " + ele1.Value.isEquip
                    + ", levelUpgrade: " + ele1.Value.levelUpgrade);
                i++;
            }
            else if (i >= itemSlots.Length)
            {
                break;
            }
            else
            {

            }
        }
    }
    private void OnValidate()
    {
        if (itemSlots.Length == 0) itemSlots = GetComponentsInChildren<ItemSlot>();
    }
    public void AddItemAmount(Item item)
    {
        if (item.id == TypeOfItem.GetType(TypeOfItem.Type.Other))
        {
            ItemSlot _itemSlot = GetItemSlot(item);
            if (_itemSlot == null)
            {
                _itemSlot = GetFirstNullItemSlot();
                if (_itemSlot != null)
                {
                    // itemManager.AddItemValue(item.type.ToString(), item.id.ToString(), item.itemIndex.ToString(), item.value);
                    Item _item = itemManager.GetItem(item.type.ToString(), item.id.ToString(), item.itemIndex.ToString());
                    _itemSlot.ITEM = _item;
                }
            }
            else
            {
                // itemManager.AddItemValue(item.type.ToString(), item.id.ToString(), item.itemIndex.ToString(), item.value);
                Item _item = itemManager.GetItem(item.type.ToString(), item.id.ToString(), item.itemIndex.ToString());
                _itemSlot.ITEM = _item;
            }
        }
        else
        {
            int indexMax = itemManager.GetMax(item.type.ToString(), item.id.ToString());
            indexMax += 1;
            item.itemIndex = indexMax;
            ItemSlot _itemSlot = GetItemSlot(item);
            if (_itemSlot == null)
            {
                ItemSlot itemSlot = GetFirstNullItemSlot();
                if (itemSlot != null)
                {
                    //  itemManager.AddItemValue(item.type.ToString(), item.id.ToString(), item.itemIndex.ToString(), 1);
                    Item _item = itemManager.GetItem(item.type.ToString(), item.id.ToString(), item.itemIndex.ToString());
                    itemSlot.ITEM = _item;
                }
            }
        }
    }
    public void ReduceItemAmount(Item item)
    {

        ItemSlot _itemSlot = GetItemSlot(item);
        // itemManager.ReduceItemValue(item.type.ToString(), item.id.ToString(), item.itemIndex.ToString(), item.value);
        Item _item = itemManager.GetItem(item.type.ToString(), item.id.ToString(), item.itemIndex.ToString());
        _itemSlot.ITEM = _item;
    }
    // Equipment
    public bool RemoveToEquip(Item item)
    {
        ItemSlot _itemSlot = GetItemSlot(item);
        if (item == null) return false;
        item.isEquip = true;
        _itemSlot.ITEM = item;
        itemManager.SaveItemIntoPlayerPrefX();
        return true;
    }
    public bool AddToUnequip(Item item)
    {
        if (item == null) return false;
        else
        {
            ItemSlot _itemSlot = GetItemSlot(item);
            if (_itemSlot == null) return false;
            else
            {
                item.isEquip = false;
                _itemSlot.ITEM = item;
                itemManager.SaveItemIntoPlayerPrefX();
                return true;
            }
        }
    }
    // Forging Ugrade
    public bool RemoveToEquipForgingUpgrade(Item item)
    {
        ItemSlot _itemSlot = GetItemSlot(item);
        if (item == null) return false;
        item.isForgingUpgrade = true;
        _itemSlot.ITEM = item;
        return true;
    }
    public bool AddToUnequipForgingUpgrade(Item item)
    {
        if (item == null) return false;
        else
        {
            ItemSlot _itemSlot = GetItemSlot(item);
            if (_itemSlot == null) return false;
            else
            {
                item.isForgingUpgrade = false;
                _itemSlot.ITEM = item;
                return true;
            }
        }
    }
    // Get Item Slot
    #region
    ItemSlot GetItemSlot(Item item)
    {
        foreach (ItemSlot _item in itemSlots)
        {
            if (_item.ITEM != null)
                if (_item.ITEM.type.Equals(item.type) &&
                    _item.ITEM.id.Equals(item.id) &&
                    _item.ITEM.itemIndex.Equals(item.itemIndex)) return _item;
        }
        return null;
    }

    ItemSlot GetFirstNullItemSlot()
    {
        foreach (ItemSlot _itemSlot in itemSlots)
        {
            if (_itemSlot.ITEM == null) return _itemSlot;
        }
        return null;
    }

    #endregion

    public void Filter(string type)
    {
        if (TypeOfItem.IsTypeOfItem(type))
        {
            foreach (ItemSlot itemSlot in itemSlots)
            {
                if (itemSlot.ITEM != null)
                {
                    if (itemSlot.ITEM.type.ToString().Equals(type))
                    {
                        itemSlot.gameObject.SetActive(true);
                    }
                    else
                    {
                        itemSlot.gameObject.SetActive(false);
                    }
                }
                else itemSlot.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (ItemSlot itemSlot in itemSlots)
            {
                itemSlot.gameObject.SetActive(true);
            }
        }
    }
}
