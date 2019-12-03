using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PopupFactory : MonoBehaviour
{
    public static PopupFactory instance;
    private Transform container;
    private Dictionary<string, BasePopup> popupDictionaries;

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
        SetPopupDictionary();
    }
    private void SetPopupDictionary()
    {
        BasePopup[] listPopup = Resources.LoadAll<BasePopup>("Popup");
        popupDictionaries = new Dictionary<string, BasePopup>();
        foreach (BasePopup _popup in listPopup)
        {
            popupDictionaries.Add(_popup.type.ToString(), _popup);
        }
    }

    public void UpdateContainer()
    {
        if (container == null) container = GameObject.FindGameObjectWithTag(KeySave.CONTAINER_POPUP).transform;
    }

    public void ShowPopup(BasePopup.TypeOfPopup type)
    {
        switch (type)
        {
            case BasePopup.TypeOfPopup.PO_ItemTooltip:
                if (ItemTooltipPopup.instance != null)
                {
                    ItemTooltipPopup.instance.ShowPopup();
                    return;
                }
                break;
        }
        InitPopup(type);
    }
    public BasePopup GetPopup(BasePopup.TypeOfPopup type)
    {
        switch (type)
        {
            case BasePopup.TypeOfPopup.PO_ItemTooltip:
                break;
        }
        return null;
    }
    public void InitPopup(BasePopup.TypeOfPopup type)
    {
        UpdateContainer();
        BasePopup popupNeed = popupDictionaries[type.ToString()];
        if (popupNeed == null) return;
        GameObject obj = Instantiate(popupNeed.gameObject, container);
        BasePopup popup = obj.GetComponent<BasePopup>();
        if (popup != null) popup.ShowPopup();
    }
    public void HideAllPopup()
    {
        int count = Enum.GetValues(typeof(BasePopup.TypeOfPopup)).Length;
        for (int i = 0; i < count; i++)
        {
            BasePopup.TypeOfPopup type = (BasePopup.TypeOfPopup)i;
            BasePopup _popup = GetPopup(type);
            if (_popup != null) _popup.HidePopup();
        }
    }

}
