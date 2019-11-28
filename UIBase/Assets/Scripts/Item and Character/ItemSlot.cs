using System;
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
                            backGround.color = itemDB.GetBackground(ITEM.levelUpgrade);
                            backGround.gameObject.SetActive(true);
                        }

                        // Set up level text
                        if (level != null && ITEM.type != (float)TypeOfItem.Type.Other)
                        {
                            level.text = (ITEM.level + 1).ToString();
                            level.gameObject.SetActive(true);
                        }


                        // Set up type of Item
                        if (typeIcon != null && ITEM.type != (float)TypeOfItem.Type.Other)
                        {
                            typeIcon.color = itemDB.GetItemType(ITEM.type.ToString());
                            typeIcon.gameObject.SetActive(true);
                        }
                        else if (ITEM.type == (float)TypeOfItem.Type.Other)
                        {
                            typeIcon.gameObject.SetActive(false);
                        }

                        // Set up amount of Item
                        if (amount != null)
                        {
                            amount.text = ITEM.value.ToString();
                            amount.gameObject.SetActive(true);
                        }
                        //
                        if (PlayerPrefs.GetInt(KeySave.ITEM_DISPLAY, 0) == 0)
                        {
                            if (isEquip != null)
                            {
                                if (_item.isEquip) isEquip.gameObject.SetActive(true);
                                else isEquip.gameObject.SetActive(false);
                            }
                        }
                        else
                        {
                            if (isForgingAndUpgrade != null)
                            {
                                if (_item.isForgingUpgrade) isForgingAndUpgrade.gameObject.SetActive(true);
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
