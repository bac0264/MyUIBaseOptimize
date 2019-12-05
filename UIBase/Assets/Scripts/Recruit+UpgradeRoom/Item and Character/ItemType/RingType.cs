using UnityEngine;
using System.Collections;
using System;

public class RingType
{
    public enum Type
    {
        Normal = 0
    }
    public static string GetRingName(float id)
    {
        foreach (string str in Enum.GetNames(typeof(Type)))
        {
            if (str.Equals(((Type)id).ToString())) return str;
        }
        return "Error Item";
    }
}
