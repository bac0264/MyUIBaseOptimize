using UnityEngine;
using System.Collections;

public class BaseStat
{
    public float value;
    public virtual void AddValue(float value)
    {
        if (value > 0)
            this.value += value;
    }
    public virtual void ReduceValue(float value)
    {
        if (value > 0)
        {
            this.value -= value;
            if (this.value < 0) this.value = 0;
        }
    }
}
