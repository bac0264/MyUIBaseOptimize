using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponType : MonoBehaviour
{
    public enum Type
    {
        knife = 0,
        crossBow = 1,
        shotGun = 2,
        bow = 3,
        mage = 4,
        doublePisol = 5
    }
    public static string GetWeaponName(float id)
    {
        foreach (string str in Enum.GetNames(typeof(Type)))
        {
            if (str.Equals(((Type)id).ToString())) return str;
        }
        return "Error Item";
    }
}
