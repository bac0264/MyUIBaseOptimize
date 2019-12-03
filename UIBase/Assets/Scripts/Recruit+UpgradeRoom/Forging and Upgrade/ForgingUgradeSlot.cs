using UnityEngine;
using System.Collections;

public class ForgingUgradeSlot : ItemSlot
{
    public enum Type
    {
        Equip,
        Upgrade
    }
    public Type typeOfFU;
    public override Item ITEM { get => base.ITEM;
        set
        {
            base.ITEM = value;
            if(ITEM != null)
            {
                if (amount != null)
                {
                    if (ITEM.type == (float)TypeOfItem.Type.Other)
                    {
                        amount.text = ITEM.value.ToString() + "/10";
                    }
                }
            }
        }
    }
}
