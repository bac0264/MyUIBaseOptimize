using UnityEngine;
using System.Collections;

public class UIBaseFunction : MonoBehaviour
{
    public enum TypeOfUI
    {
        UI_RecruitAndUpgradeRoom,
    }
    public TypeOfUI type;
    public virtual void ShowUI()
    {
        gameObject.SetActive(true);
    }
}    
