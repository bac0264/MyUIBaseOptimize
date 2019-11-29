using UnityEngine;
using System.Collections;

public class ForgingUpgradePanel : MonoBehaviour
{
    public ItemSlotList itemSlotList;
    public ForgingUgradeSlotList forgingUpgradeSlotList;
    private void Awake()
    {
        forgingUpgradeSlotList.OnRightClickEvent += Unequip;
    }
    private void OnValidate()
    {
        if (itemSlotList == null) itemSlotList = FindObjectOfType<ItemSlotList>();
        if (forgingUpgradeSlotList == null) forgingUpgradeSlotList = FindObjectOfType<ForgingUgradeSlotList>();
    }
    private void OnEnable()
    {
        PlayerPrefs.SetInt(KeySave.ITEM_DISPLAY, 1);
        itemSlotList.OnRightClickEvent += Equip;
        itemSlotList.SetupEvent();
        forgingUpgradeSlotList.SetupData();
        itemSlotList.DisplayFU();
    }
    private void OnDisable()
    {
        itemSlotList.RemoveEvent();
        itemSlotList.OnRightClickEvent -= Equip;
        itemSlotList.UnactiveMarked();
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
    public void UpgradeItem()
    {       
        int upgrade = forgingUpgradeSlotList.Upgrade();
        if (upgrade == 2 || upgrade == 1 || upgrade == 3) itemSlotList.SetupData();
    }
}
