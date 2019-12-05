using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquipmentPanel : MonoBehaviour
{
    public static EquipmentPanel instance;

    public CharacterStatManager CharacterStatManager;
    public CharacterStatUI characterUI;
    public SkeletonCharacter skeletonCharacter;
    //public SkeletonGraphic
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
        PlayerPrefs.SetInt(KeySave.ITEM_DISPLAY, 0);
        itemSlotList.OnRightClickEvent += ShowTooltip;
        itemSlotList.SetupEvent();
        itemSlotList.SetupData();
        equipSlotList.SetupData();
        itemSlotList.DisplayEquipment();
        characterUI.UpdateCharacterStat(CharacterStatManager);
        skeletonCharacter.RefreshUI();
    }
    private void OnDisable()
    {
        itemSlotList.RemoveEvent();
        itemSlotList.OnRightClickEvent -= ShowTooltip;
        itemSlotList.UnactiveMarked();
    }
    private void OnValidate()
    {
        if(skeletonCharacter == null) skeletonCharacter = GetComponentInChildren<SkeletonCharacter>();
        if (CharacterStatManager == null) CharacterStatManager = FindObjectOfType<CharacterStatManager>();
        if (itemSlotList == null) itemSlotList = GetComponentInChildren<ItemSlotList>();
        if (equipSlotList == null) equipSlotList = GetComponentInChildren<EquipmentSlotList>();
        if (characterUI == null) characterUI = GetComponentInChildren<CharacterStatUI>();
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
                item.Equip(CharacterStatManager);
                characterUI.UpdateCharacterStat(CharacterStatManager);
                if (item.type == (float)TypeOfItem.Type.Weapon) skeletonCharacter.RefreshUI();
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
                item.Unequip(CharacterStatManager);
                characterUI.UpdateCharacterStat(CharacterStatManager);
                if(item.type == (float)TypeOfItem.Type.Weapon)skeletonCharacter.RefreshUI();
            }
        }
    }
    public void UnequipNoChangeAnimation(Item item)
    {
        if (item != null && item.value > 0)
        {
            if (itemSlotList.AddToUnequip(item))
            {
                equipSlotList.RemoveToUnequip(item);
                item.Unequip(CharacterStatManager);
                characterUI.UpdateCharacterStat(CharacterStatManager);
            }
        }
    }
}
