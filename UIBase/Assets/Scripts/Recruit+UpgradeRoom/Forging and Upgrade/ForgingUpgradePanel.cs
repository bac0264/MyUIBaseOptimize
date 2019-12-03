using UnityEngine;
using System.Collections;

public class ForgingUpgradePanel : MonoBehaviour
{
    public static ForgingUpgradePanel instance;
    public ItemSlotList itemSlotList;
    public ForgingUgradeSlotList forgingUpgradeSlotList;
    private void Awake()
    {
        if (instance == null) instance = this;

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
            if (forgingUpgradeSlotList.RemoveToUnequip(item))
            {
                Debug.Log("run");
                itemSlotList.AddToUnequipForgingUpgrade(item);
            }
        }
    }
    public void UpgradeItem()
    {       
        int upgrade = forgingUpgradeSlotList.Upgrade();
        Debug.Log(upgrade);
        if (upgrade == 2 || upgrade == 1 || upgrade == 3) itemSlotList.SetupData();
    }
}
