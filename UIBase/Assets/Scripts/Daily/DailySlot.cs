using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class DailySlot : MonoBehaviour, IPointerClickHandler
{
    private const int Picked = 0; // Daily picked
    private const int Default = 1; // Daily image default
    private const int Next = 2; // Open next daily
    [SerializeField]
    private int id;
    [SerializeField]
    private bool isRecieve;
    [SerializeField]
    private bool isOpen;

    public DailyPrice price;

    public Transform container;
    public List<Image> DailyDisplays;
    public Text day;
    public Text value;
    // public DailyReward dailyReward;

    public event Action<DailySlot> OnRightClickEvent;
    public int ID
    {
        set
        {
            id = value;
        }
        get
        {
            return id;
        }
    }
    public bool IsRecieve
    {
        set
        {
            isRecieve = value;
            if (isRecieve)
            {
                DailyDisplay(Picked);
            }
        }
        get
        {
            return isRecieve;
        }
    }
    public bool IsOpen
    {
        set
        {
            isOpen = value;
            if (isOpen)
            {
                DailyDisplay(Next);
            }
            else 
            {
                DailyDisplay(Default);
            }
        }
        get
        {
            return isOpen;
        }
    }

    public void RecieveReward()
    {
        IResourceManager irsm = DIContainer.GetModule<IResourceManager>();
        irsm.AddResourceNeed(price.reward.Type.ToString(), price.reward.value);
    }
    public void DailyDisplay(int index)
    {
        for(int i = 0; i < DailyDisplays.Count; i++)
        {
            if (i == index) DailyDisplays[i].gameObject.SetActive(true);
            else 
            {
                DailyDisplays[i].gameObject.SetActive(false);
            }
        }
    }
    public void SetupSprite()
    {
        DailyDisplays[Picked].sprite = DailySpriteDatabase.instance.getPick(price.reward.Type.ToString());
        DailyDisplays[Default].sprite = DailySpriteDatabase.instance.getBackground(price.reward.Type.ToString());
    }
    // Onvalidate + Process Event
    #region

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && (eventData.button == PointerEventData.InputButton.Right || eventData.clickCount > 0))
        {
            if (OnRightClickEvent != null)
            {
                OnRightClickEvent(this);
            }
        }
    }
    #endregion
}
[System.Serializable]
public class DailyPrice
{
    public ResourceStat reward;
}

