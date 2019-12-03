using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAbtractFactory : MonoBehaviour
{
    public static UIAbtractFactory instance;
    private Transform container;
    public Dictionary<string, UIBase> uiList = new Dictionary<string, UIBase>();
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
        UIBase[] uiResourceList = Resources.LoadAll<UIBase>("UI");
        uiList = new Dictionary<string, UIBase>();
        foreach (UIBase _ui in uiResourceList)
        {
            uiList.Add(_ui.type.ToString(), _ui);
        }
    }

    public void UpdateContainer()
    {
        if (container == null) container = GameObject.FindGameObjectWithTag(KeySave.CONTAINER_UI).transform;
    }

    public void ShowPopup(UIBase.TypeOfUI type)
    {
        switch (type)
        {
            case UIBase.TypeOfUI.UI_RecruitAndUpgradeRoom:
                if (UIRecruitAndUpgradeRoom.instance != null)
                {
                    UIRecruitAndUpgradeRoom.instance.ShowUI();
                    return;
                }
                break;
        }
        InitUI(type);
    }
    public UIBase GetUI(UIBase.TypeOfUI type)
    {
        switch (type)
        {
            case UIBase.TypeOfUI.UI_RecruitAndUpgradeRoom:
                break;
        }
        return null;
    }
    public void InitUI(UIBase.TypeOfUI type)
    {
        UpdateContainer();
        UIBase popupNeed = uiList[type.ToString()];
        if (popupNeed == null) return;
        GameObject obj = Instantiate(popupNeed.gameObject, container);
        UIBase popup = obj.GetComponent<UIBase>();
        if (popup != null) popup.ShowUI();
    }

}
