﻿using UnityEngine;
using System.Collections;

public class EquipmentPanel : MonoBehaviour
{
    public static EquipmentPanel instance;

    public Character character;

    public ItemSlotList itemSlotList;
    public EquipmentSlotList equipSlotList;
    // Use this for initialization
    void Awake()
    {
        if (instance == null) instance = this;
        equipSlotList.OnRightClickEvent += Unequip;
    }
    private void OnEnable()
    {
        itemSlotList.OnRightClickEvent += ShowTooltip;
        itemSlotList.SetupEvent();
    }
    private void OnDisable()
    {
        itemSlotList.RemoveEvent();
        itemSlotList.OnRightClickEvent -= ShowTooltip;
    }
    private void OnValidate()
    {
        if (itemSlotList == null) itemSlotList = GetComponentInChildren<ItemSlotList>();
        if (equipSlotList == null) equipSlotList = GetComponentInChildren<EquipmentSlotList>();
    }
    public void ShowTooltip(Item item)
    {
        if (item != null && item.value > 0)
        {
            if (PopupFactory.instance != null)
                PopupFactory.instance.ShowPopup(BasePopup.TypeOfPopup.PO_ItemTooltip);
            if (ItemTooltipPopup.instance != null) ItemTooltipPopup.instance.ShowItemTooltip(item);
        }

    }
    public void Equip(Item item)
    {
        if (item != null && item.value > 0)
        {
            if (equipSlotList.AddToEquip(item))
            {
                itemSlotList.RemoveToEquip(item);
                item.Equip(this);
                if (CharacterStatUI.instance != null) CharacterStatUI.instance.UpdateCharacterStat(this);
            }
        }

    }
    public void Unequip(Item item)
    {
        if (item != null && item.value > 0)
        {
            if (itemSlotList.AddToUnequip(item))
            {
                equipSlotList.RemoveToUnequip(item);
                item.Unequip(this);
                if (CharacterStatUI.instance != null) CharacterStatUI.instance.UpdateCharacterStat(this);
            }
        }
    }

}