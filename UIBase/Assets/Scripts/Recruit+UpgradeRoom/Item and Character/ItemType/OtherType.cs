using UnityEngine;
using System.Collections;
using System;

public class OtherType
{
    public enum Type
    {
        RUBY_Weapon = 0,
        RUBY_Armor = 1,
        RUBY_RING = 2,
        RUBY_Amulet = 3,
        EQUIPMENT_SCROLL = 4,
        ENERGON = 5
    }
    public static string GetOtherName(float id)
    {
        foreach (string str in Enum.GetNames(typeof(Type)))
        {
            if (str.Equals(((Type)id).ToString())) return str;
        }
        return "Error Item";
    }
}
