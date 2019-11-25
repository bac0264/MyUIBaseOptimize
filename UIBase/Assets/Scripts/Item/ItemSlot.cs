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
    public Image type;
    public Text level;
    public Action<Item> OnRightClickEvent;

    public virtual Item ITEM
    {
        set
        {
            _item = value;
            if (_item.value == 0)
            {
                backGround.gameObject.SetActive(false);
                _item = null;
            }
            else
            {
                backGround.gameObject.SetActive(true);
                ItemDataBase itemDB = ItemDataBase.instance;
                if (itemDB != null)
                {
                    if (icon != null)
                    {
                        icon.sprite = itemDB.GetItemSprite(ITEM.type.ToString(),
                            ITEM.id.ToString(), ITEM.levelUpgrade.ToString());
                        if (icon.sprite == null)
                        {
                            backGround.gameObject.SetActive(false);
                            _item = null;
                            return;
                        }
                    }
                    if (backGround != null)
                        backGround.color = itemDB.GetColor(ITEM.levelUpgrade);
                    if (level != null) level.text = ITEM.level.ToString();
                    if (isEquip != null)
                    {
                        if (_item.isEquip) isEquip.gameObject.SetActive(true);
                        else isEquip.gameObject.SetActive(false);
                    }
                    if (type != null) type.sprite = itemDB.GetItemType(ITEM.type.ToString());
                }
            }
        }
        get
        {
            return _item;
        }
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
