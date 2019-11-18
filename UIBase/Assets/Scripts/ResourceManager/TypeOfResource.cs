using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class TypeOfResource
{
    public enum Type
    {
        Gold,
        Gem,
        Exp,
        Exception
    }
    public Type type;
    public static Type ConvertStringToEnum(string str)
    {
        try
        {
            Type _type = (Type)Enum.Parse(typeof(Type), str);
            return _type;
        }
        catch {
            return Type.Exception;
        }
    }

}
