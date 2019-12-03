using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAbtractFactory : MonoBehaviour
{
    public static UIAbtractFactory instance;
    public Transform container;
    public Dictionary<string, UIBaseFunction> uiList = new Dictionary<string, UIBaseFunction>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this);
        }
        SetUIDictionary();
    }
    private void SetUIDictionary()
    {
        UIBaseFunction[] uiResourceList = Resources.LoadAll<UIBaseFunction>("UIHidden");
        uiList = new Dictionary<string, UIBaseFunction>();
        foreach (UIBaseFunction _ui in uiResourceList)
        {
            uiList.Add(_ui.type.ToString(), _ui);
        }
    }

    public void UpdateContainer()
    {
        if (container == null) container = GameObject.FindGameObjectWithTag(KeySave.CONTAINER_POPUP).transform;
    }

    public void ShowPopup(UIBaseFunction.TypeOfUI type)
    {
        switch (type)
        {
            case UIBaseFunction.TypeOfUI.UI_RecruitAndUpgradeRoom:
                if (ItemTooltipPopup.instance != null)
                {
                    ItemTooltipPopup.instance.ShowPopup();
                    return;
                }
                break;
        }
        InitUI(type);
    }
    public UIBaseFunction GetUI(UIBaseFunction.TypeOfUI type)
    {
        switch (type)
        {
            case UIBaseFunction.TypeOfUI.UI_RecruitAndUpgradeRoom:
                break;
        }
        return null;
    }
    public void InitUI(UIBaseFunction.TypeOfUI type)
    {
        UpdateContainer();
        UIBaseFunction popupNeed = uiList[type.ToString()];
        if (popupNeed == null) return;
        GameObject obj = Instantiate(popupNeed.gameObject, container);
        UIBaseFunction popup = obj.GetComponent<UIBaseFunction>();
        if (popup != null) popup.ShowUI();
    }

}
