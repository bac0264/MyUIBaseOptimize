using UnityEngine;
using System.Collections;

public class UIBaseFunction : MonoBehaviour
{
    public virtual void ShowFunction()
    {
        gameObject.SetActive(true);
    }
}    
