﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    private Item _item;
    public Image icon;
    public Image backGround;
    public Image isEquip;
    public Image isForgingAndUpgrade;
    public Image typeIcon;
    public Text level;
    public Text amount;
    public Action<Item> OnRightClickEvent;

    public virtual Item ITEM
    {
        set
        {
            _item = value;
            if (_item != null)
            {
                if (_item.value == 0)
                {
                    HideUI();
                    _item = null;
                }
                else
                {
                    ItemDataBase itemDB = ItemDataBase.instance;
                    if (itemDB != null)
                    {
                        // Set up Icon
                        if (icon != null)
                        {
                            icon.sprite = itemDB.GetItemSprite(ITEM.type.ToString(),
                                ITEM.id.ToString(), ITEM.levelUpgrade.ToString());
                            if (icon.sprite == null)
                            {
                                icon.gameObject.SetActive(false);
                                backGround.gameObject.SetActive(false);
                                return;
                            }
                            icon.gameObject.SetActive(true);
                        }

                        // Set up Background
                        if (backGround != null)
                        {
                            backGround.sprite = itemDB.GetBackground(ITEM.levelUpgrade);
                            backGround.gameObject.SetActive(true);
                        }

                        // Set up level text
                        if (level != null)
                        {
                            if (ITEM.type != (float)TypeOfItem.Type.Other)
                            {
                                level.text = (ITEM.level + 1).ToString();
                                level.gameObject.SetActive(true);
                            }
                            else level.gameObject.SetActive(false);
                        }

                        #region
                        // Set up type of Item
                        //if (typeIcon != null && ITEM.type != (float)TypeOfItem.Type.Other)
                        //{
                        //    typeIcon.color = itemDB.GetItemType(ITEM.type.ToString());
                        //    typeIcon.gameObject.SetActive(true);
                        //}
                        //else if (ITEM.type == (float)TypeOfItem.Type.Other)
                        //{
                        //    if (ITEM.id != 0)
                        //    {
                        //        typeIcon.color = itemDB.GetItemType((ITEM.id - 1).ToString());
                        //        typeIcon.gameObject.SetActive(true);
                        //    }
                        //    else
                        //        typeIcon.gameObject.SetActive(false);
                        //}
                        #endregion
                        // Set up amount of Item
                        if (amount != null)
                        {
                            if (ITEM.type == (float)TypeOfItem.Type.Other)
                            {
                                amount.text = ITEM.value.ToString();
                                amount.enabled = true;
                                amount.gameObject.SetActive(true);
                            }
                            else
                            {
                                amount.enabled = false;
                                amount.gameObject.SetActive(false);
                            }
                        }
                        //
                        if (PlayerPrefs.GetInt(KeySave.ITEM_DISPLAY, 0) == 0)
                        {
                            if (isEquip != null)
                            {
                                if (ITEM.isEquip) isEquip.gameObject.SetActive(true);
                                else isEquip.gameObject.SetActive(false);
                            }
                        }
                        else
                        {
                            if (isForgingAndUpgrade != null)
                            {
                                Debug.Log(ITEM.isForgingUpgrade);
                                if (ITEM.isForgingUpgrade) isForgingAndUpgrade.gameObject.SetActive(true);
                                else isForgingAndUpgrade.gameObject.SetActive(false);
                            }
                        }
                    }
                }
            }
            else
            {
                HideUI();
            }
        }
        get
        {
            return _item;
        }
    }
    public void HideUI()
    {
        if (backGround != null) backGround.gameObject.SetActive(false);
        if (isEquip != null) isEquip.gameObject.SetActive(false);
        if (isForgingAndUpgrade != null) isForgingAndUpgrade.gameObject.SetActive(false);
        if (level != null) level.gameObject.SetActive(false);
        if (amount != null) amount.gameObject.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && (eventData.button == PointerEventData.InputButton.Right || eventData.clickCount > 0))
        {
            if (OnRightClickEvent != null && _item != null)
            {
                OnRightClickEvent(_item);
            }
        }

    }
}
