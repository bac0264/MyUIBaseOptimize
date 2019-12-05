using UnityEngine;
using System.Collections;
using System;

public class ArmorType
{
    public enum Type
    {
        Normal = 0
    }
    public static string GetArmorName(float id)
    {
        foreach (string str in Enum.GetNames(typeof(Type)))
        {
            if (str.Equals(((Type)id).ToString())) return str;
        }
        return "Error Item";
    }
}
