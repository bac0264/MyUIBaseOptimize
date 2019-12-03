using UnityEngine;
using System.Collections;

public class UIBase : MonoBehaviour
{
    public enum TypeOfUI
    {
        UI_Daily = 0,
        UI_RecruitAndUpgradeRoom = 1,
    }
    public TypeOfUI type;
    public virtual void ShowUI()
    {
        gameObject.SetActive(true);
    }
    public virtual void HideUI()
    {
        gameObject.SetActive(false);
    }
}    
