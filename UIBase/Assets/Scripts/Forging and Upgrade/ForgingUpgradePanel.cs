using UnityEngine;
using System.Collections;

public class ForgingUpgradePanel : MonoBehaviour
{
    public ItemSlotList itemSlotList;
    public ForgingUgradeSlotList forgingUpgradeSlotList;
    private void OnValidate()
    {
        if (itemSlotList == null) itemSlotList = FindObjectOfType<ItemSlotList>();
        if (forgingUpgradeSlotList == null) forgingUpgradeSlotList = FindObjectOfType<ForgingUgradeSlotList>();
    }
    private void OnEnable()
    {
        itemSlotList.OnRightClickEvent += Equip;
        itemSlotList.SetupEvent();
       // equipSlotList.OnRightClickEvent += Unequip;
    }
    private void OnDisable()
    {
        itemSlotList.RemoveEvent();
        itemSlotList.OnRightClickEvent -= Equip;
        // equipSlotList.OnRightClickEvent -= Unequip;
    }
    public void Equip(Item item)
    {
        if (item != null && item.value > 0)
        {
            if (forgingUpgradeSlotList.AddToEquip(item))
            {
                itemSlotList.RemoveToEquipForgingUpgrade(item);
            }
        }

    }
    public void Unequip(Item item)
    {
        if (item != null && item.value > 0)
        {
            if (itemSlotList.AddToUnequipForgingUpgrade(item))
            {
                forgingUpgradeSlotList.RemoveToUnequip(item);
            }
        }
    }
}
