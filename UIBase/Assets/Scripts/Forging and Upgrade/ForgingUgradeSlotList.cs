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
        itemManager = DIContainer.GetModule<IItemManager>();
    }
    public void SetupEvent()
    {
        foreach (ForgingUgradeSlot slot in forgingUgradeSlots)
        {
            slot.OnRightClickEvent += OnRightClickEvent;
        }
    }
    public void SetupData()
    {
        foreach (ForgingUgradeSlot slot in forgingUgradeSlots)
        {
            slot.ITEM = null;
        }
    }
    private void OnValidate()
    {
        if (forgingUgradeSlots.Length == 0) forgingUgradeSlots = GetComponentsInChildren<ForgingUgradeSlot>();
    }
    public bool AddToEquip(Item item)
    {
        if (item.isForgingUpgrade) return false;
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
            if (itemSlot.ITEM == null && itemSlot.typeOfFU.ToString().Equals(ForgingUgradeSlot.Type.Equip.ToString()))
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
            if (item == itemSlot.ITEM && itemSlot.typeOfFU.ToString().Equals(ForgingUgradeSlot.Type.Equip.ToString()))
            {
                return itemSlot;
            }
        }
        return null;
    }
    ForgingUgradeSlot GetFirstForgingUgradeSlot()
    {
        foreach (ForgingUgradeSlot itemSlot in forgingUgradeSlots)
        {
            if (itemSlot.ITEM != null && itemSlot.typeOfFU.ToString().Equals(ForgingUgradeSlot.Type.Equip.ToString()))
            {
                return itemSlot;
            }
        }
        return null;
    }
    ForgingUgradeSlot GetUpgradeForgingUgradeSlot()
    {
        foreach (ForgingUgradeSlot itemSlot in forgingUgradeSlots)
        {
            if (itemSlot.typeOfFU.ToString().Equals(ForgingUgradeSlot.Type.Upgrade.ToString()))
            {
                return itemSlot;
            }
        }
        return null;
    }
    #endregion
    public int Upgrade()
    {
        // return 0 => false, return 1 => upgrading follow type 1, return 2 => upgrading follow type 2
        ForgingUgradeSlot fuSlot = GetNullForgingUgradeSlot();
        // check, if having Null Slot -> still no having full of fuItem
        if (fuSlot != null) return 0;
        // get firstItem
        fuSlot = GetFirstForgingUgradeSlot();
        List<ForgingUgradeSlot> fuSlots = new List<ForgingUgradeSlot>();
        foreach (ForgingUgradeSlot itemSlot in forgingUgradeSlots)
        {
            if (itemSlot.typeOfFU.ToString().Equals(ForgingUgradeSlot.Type.Equip.ToString()))
            {
                fuSlots.Add(itemSlot);
            }
        }
        int count_1 = 0; // count 3 types are the same about id, type, levelupgrade
        int count_2 = 0; // count 3 type are the same about levelupgrade
        foreach (ForgingUgradeSlot itemSlot in fuSlots)
        {
            if (fuSlot.ITEM.id == itemSlot.ITEM.id && fuSlot.ITEM.type == itemSlot.ITEM.type
                && fuSlot.ITEM.levelUpgrade == itemSlot.ITEM.levelUpgrade)
            {
                count_1++;
            }
            if (fuSlot.ITEM.levelUpgrade == itemSlot.ITEM.levelUpgrade)
            {
                if (fuSlot.ITEM.type != (float)TypeOfItem.Type.Other)
                    count_2++;
            }

            {

            }
        }
        if (count_1 == 3)
        {
            int levelUpgrade = (int)fuSlot.ITEM.levelUpgrade + 1;
            int id = (int)fuSlot.ITEM.id;
            int type = (int)fuSlot.ITEM.type;
            if (levelUpgrade > KeySave.MAX_LEVELUPGRADE_ITEM) levelUpgrade = KeySave.MAX_LEVELUPGRADE_ITEM;
            foreach (ForgingUgradeSlot itemSlot in fuSlots)
            {
                itemManager.RemoveItem(itemSlot.ITEM);
                itemSlot.ITEM.value = 0;
                itemSlot.ITEM = itemSlot.ITEM;
            }
            Item upgradeItem = new Item(0, id, type, 1, 0, levelUpgrade, false);
            itemManager.AddItem(upgradeItem);
            ForgingUgradeSlot upgradeSlot = GetUpgradeForgingUgradeSlot();
            upgradeSlot.ITEM = upgradeItem;
            itemManager.SaveItemIntoPlayerPrefX();
            return 1;
        }
        else if (count_1 != 3 && count_2 == 3)
        {
            int type = UnityEngine.Random.Range((int)TypeOfItem.Type.Weapon, (int)TypeOfItem.Type.Other);
            int levelUpgrade = (int)fuSlot.ITEM.levelUpgrade + 1;
            if (levelUpgrade > KeySave.MAX_LEVELUPGRADE_ITEM) levelUpgrade = KeySave.MAX_LEVELUPGRADE_ITEM;
            Item upgradeItem = new Item(0, 0, type, 1, 0, levelUpgrade, false);
            itemManager.AddItem(upgradeItem);
            foreach (ForgingUgradeSlot itemSlot in fuSlots)
            {
                if (itemSlot.ITEM != null)
                {
                    itemManager.RemoveItem(itemSlot.ITEM);
                    itemSlot.ITEM.value = 0;
                    itemSlot.ITEM = itemSlot.ITEM;
                }
            }
            ForgingUgradeSlot upgradeSlot = GetUpgradeForgingUgradeSlot();
            upgradeSlot.ITEM = upgradeItem;
            itemManager.SaveItemIntoPlayerPrefX();
            return 2;
        }
        else
        {
            return 0;
        }
    }
}
