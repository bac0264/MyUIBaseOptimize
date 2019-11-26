using UnityEngine;
using System.Collections;

public class ItemFilter : MonoBehaviour
{
    public void All()
    {
        if (CharacterAction.instance != null) CharacterAction.instance.itemSlotList.Filter("-1");
    }
    public void Weapon()
    {
        if (CharacterAction.instance != null) CharacterAction.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Weapon).ToString());
    }
    public void Ring()
    {
        if (CharacterAction.instance != null) CharacterAction.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Ring).ToString());
    }
    public void Amulet()
    {
        if (CharacterAction.instance != null) CharacterAction.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Amulet).ToString());
    }
    public void Armor()
    {
        if (CharacterAction.instance != null) CharacterAction.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Armor).ToString());
    }
    public void Other()
    {
        if (CharacterAction.instance != null) CharacterAction.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Other).ToString());
    }

}
