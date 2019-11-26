using UnityEngine;
using System.Collections;

public class CharacterAction : MonoBehaviour
{
    public static CharacterAction instance;
    public ItemSlotList itemSlotList;
    public EquipmentSlotList equipSlotList;
    // Use this for initialization
    void Awake()
    {
        if (instance == null) instance = this;
        itemSlotList.OnRightClickEvent += ShowTooltip;
        equipSlotList.OnRightClickEvent += Unequip;
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
            }
        }
    }

}
