using UnityEngine;
using System.Collections;

[System.Serializable]
public class TypeOfItem 
{
    public enum Type
    {
        Weapon = 0,
        Armor = 1,
        Ring = 2,
        Amulet = 3,
        Other = 4
    }
    public Type type;
    public static int GetType(Type type)
    {
        return (int)type;
    }
}
