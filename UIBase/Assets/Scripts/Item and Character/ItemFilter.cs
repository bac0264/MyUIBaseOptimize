using UnityEngine;
using System.Collections;

public class ItemFilter : MonoBehaviour
{
    public void All()
    {
        if (EquipmentPanel.instance != null) EquipmentPanel.instance.itemSlotList.Filter("-1");
    }
    public void Weapon()
    {
        if (EquipmentPanel.instance != null) EquipmentPanel.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Weapon).ToString());
    }
    public void Ring()
    {
        if (EquipmentPanel.instance != null) EquipmentPanel.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Ring).ToString());
    }
    public void Amulet()
    {
        if (EquipmentPanel.instance != null) EquipmentPanel.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Amulet).ToString());
    }
    public void Armor()
    {
        if (EquipmentPanel.instance != null) EquipmentPanel.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Armor).ToString());
    }
    public void Other()
    {
        if (EquipmentPanel.instance != null) EquipmentPanel.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Other).ToString());
    }

}
