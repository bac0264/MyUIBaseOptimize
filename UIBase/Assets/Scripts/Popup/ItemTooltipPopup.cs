using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemTooltipPopup : BasePopup
{
    public static ItemTooltipPopup instance;
    private Item item;
    public Text HP;
    public Text Dame;
    public Text Power;
    public Text OtherText;
    public Image Background;
    public Image Icon;
   // public Image Type;

    public Button _equip;
    public Button _unequip;

    public GameObject Other;
    public GameObject NotOther;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void ShowItemTooltip(Item item)
    {
        ItemDataBase db = ItemDataBase.instance;
        this.item = item;
        if (this.item != null && this.item.value > 0)
        {
            if (!item.type.ToString().Equals(((float)TypeOfItem.Type.Other).ToString()))
            {
                HP.text = ": "+item.hp;
                Dame.text = ": "+item.dame;
                Power.text = ": "+item.power;
                if (db != null)
                {
                    Background.sprite = db.GetBackground(item.levelUpgrade);
                    Icon.sprite = db.GetItemSprite(item.type.ToString(), item.id.ToString(), item.levelUpgrade.ToString());
                   // Type.color = db.GetItemType(item.type.ToString());
                   // Type.gameObject.SetActive(true);
                }
                _equip.gameObject.SetActive(true);
                _unequip.gameObject.SetActive(false);
                Other.SetActive(false);
                NotOther.SetActive(true);
            }
            else
            {
                OtherText.text = "That's item which is so fucking incredible";
                if (db != null)
                {
                    if (item.id.ToString().Equals("0"))
                    {
                        Background.sprite = db.GetBackground(item.levelUpgrade);
                    }
                    else Background.color = new Color(0, 0, 0, 0);
                    Icon.sprite = db.GetItemSprite(item.type.ToString(), item.id.ToString(), item.levelUpgrade.ToString());
                    //Type.gameObject.SetActive(false);
                }
                _equip.gameObject.SetActive(false);
                _unequip.gameObject.SetActive(false);
                Other.SetActive(true);
                NotOther.SetActive(false);
            }
            Background.gameObject.SetActive(true);
            Icon.gameObject.SetActive(true);
        }
        else HideItemTooltip();
    }
    public void HideItemTooltip()
    {
        gameObject.SetActive(false);
    }

    public void Equip()
    {
        EquipmentPanel character = EquipmentPanel.instance;
        if (character != null && item != null && item.value > 0)
        {
            character.Equip(item);
        }
        HideItemTooltip();
    }
    public void Unequip()
    {
        HideItemTooltip();
    }
}
