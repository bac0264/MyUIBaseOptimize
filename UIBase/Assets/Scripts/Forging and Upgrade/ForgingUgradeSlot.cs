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
}
