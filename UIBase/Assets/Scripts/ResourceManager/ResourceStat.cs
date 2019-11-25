using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ResourceStat : BaseStat
{
    public TypeOfResource Type;

    public ResourceStat(float value, TypeOfResource Type)
    {
        this.value = value;
        this.Type = Type;
    }
}
