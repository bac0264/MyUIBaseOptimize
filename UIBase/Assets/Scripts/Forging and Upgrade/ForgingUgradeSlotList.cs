using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ForgingUgradeSlotList : MonoBehaviour
{
    public ForgingUgradeSlot[] forgingUgradeSlots;
    public IItemManager itemManager;
    public Action<Item> OnRightClickEvent;

    public virtual void Start()
    {
        SetupEvent();
    }
    private void OnEnable()
    {
        SetupData();
    }
    public void SetupData()
    {
        itemManager = DIContainer.GetModule<IItemManager>();
        List<Item> item = itemManager.EquipmentItemList();
        for (int i = 0; i < forgingUgradeSlots.Length; i++)
        {
            for (int j = 0; j < item.Count; j++)
            {
                if (forgingUgradeSlots[i].ITEM.isForgingUpgrade)
                {
                    forgingUgradeSlots[i].ITEM = item[j];
                    break;
                }
            }
        }
    }
    public void SetupEvent()
    {
        foreach (ForgingUgradeSlot slot in forgingUgradeSlots)
        {
            slot.OnRightClickEvent += OnRightClickEvent;
        }
    }
    private void OnValidate()
    {
        if (forgingUgradeSlots.Length == 0) forgingUgradeSlots = GetComponentsInChildren<ForgingUgradeSlot>();
    }
    public bool AddToEquip(Item item)
    {

        ForgingUgradeSlot _itemSlot = GetNullForgingUgradeSlot();
        if (_itemSlot == null) return false;
        _itemSlot.ITEM = item;
        return true;

    }
    public bool RemoveToUnequip(Item item)
    {
        ForgingUgradeSlot _itemSlot = GetForgingUgradeSlot(item);
        if (_itemSlot == null) return false;
        Item _item = new Item(0);
        _itemSlot.ITEM = _item;
        return true;
    }
    // Get Item Slot
    #region
    ForgingUgradeSlot GetNullForgingUgradeSlot()
    {
        foreach (ForgingUgradeSlot itemSlot in forgingUgradeSlots)
        {
            if (itemSlot.ITEM == null)
            {
                return itemSlot;
            }
        }
        return null;
    }
    ForgingUgradeSlot GetForgingUgradeSlot(Item item)
    {
        foreach (ForgingUgradeSlot itemSlot in forgingUgradeSlots)
        {
            if (item == itemSlot.ITEM)
            {
                return itemSlot;
            }
        }
        return null;
    }


    #endregion
}
