using UnityEngine;
using System.Collections;

public class CharacterAction : MonoBehaviour
{
    public ItemSlotList itemSlotList;
    public EquipmentSlotList equipSlotList;
    // Use this for initialization
    void Awake()
    {
        itemSlotList.OnRightClickEvent += Equip;
        equipSlotList.OnRightClickEvent += Unequip;
    }
    private void OnValidate()
    {
        if (itemSlotList == null) itemSlotList = GetComponentInChildren<ItemSlotList>();
        if (equipSlotList == null) equipSlotList = GetComponentInChildren<EquipmentSlotList>();
    }
    public void Equip(Item item)
    {
        if (equipSlotList.AddToEquip(item))
        {
            itemSlotList.RemoveToEquip(item);
        }

    }
    public void Unequip(Item item)
    {
        if (itemSlotList.AddToUnequip(item))
        {
            equipSlotList.RemoveToUnequip(item);
        }
    }

}
public class CharacterStat
{
    public BaseStat ATK;
    public BaseStat HP;
    public BaseStat POWER;
}
