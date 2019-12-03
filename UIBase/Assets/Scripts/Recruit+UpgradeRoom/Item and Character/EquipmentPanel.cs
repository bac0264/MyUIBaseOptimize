using UnityEngine;
using System.Collections;

public class EquipmentPanel : MonoBehaviour
{
    public static EquipmentPanel instance;

    public Character character;

    public ItemSlotList itemSlotList;
    public EquipmentSlotList equipSlotList;
    // Use this for initialization
    void Awake()
    {
        if (instance == null) instance = this;
        equipSlotList.OnRightClickEvent += Unequip;
    }

    private void OnEnable()
    {
        PlayerPrefs.SetInt(KeySave.ITEM_DISPLAY, 0);
        itemSlotList.OnRightClickEvent += ShowTooltip;
        itemSlotList.SetupEvent();
        itemSlotList.SetupData();
        equipSlotList.SetupData();
        itemSlotList.DisplayEquipment();
    }
    private void OnDisable()
    {
        itemSlotList.RemoveEvent();
        itemSlotList.OnRightClickEvent -= ShowTooltip;
        itemSlotList.UnactiveMarked();
    }
    private void OnValidate()
    {
        if (character == null) character = FindObjectOfType<Character>();
        if (itemSlotList == null) itemSlotList = GetComponentInChildren<ItemSlotList>();
        if (equipSlotList == null) equipSlotList = GetComponentInChildren<EquipmentSlotList>();
    }
    public void ShowTooltip(Item item)
    {
        if (item != null && item.value > 0)
        {
            if (PopupFactory.instance != null)
                PopupFactory.instance.ShowPopup(BasePopup.TypeOfPopup.PO_ItemTooltip);
            if (ItemTooltipPopup.instance != null) ItemTooltipPopup.instance.ShowItemTooltip(item);
        }

    }
    public void Equip(Item item)
    {
        if (item != null && item.value > 0)
        {
            if (equipSlotList.AddToEquip(item))
            {
                itemSlotList.RemoveToEquip(item);
                item.Equip(this);
                if (CharacterStatUI.instance != null) CharacterStatUI.instance.UpdateCharacterStat(this);
            }
        }

    }
    public void Unequip(Item item)
    {
        if (item != null && item.value > 0)
        {
            if (itemSlotList.AddToUnequip(item))
            {
                equipSlotList.RemoveToUnequip(item);
                item.Unequip(this);
                Debug.Log("item.id: " + item.id + ", " + item.type);

                Debug.Log("unequip");
                if (CharacterStatUI.instance != null) CharacterStatUI.instance.UpdateCharacterStat(this);
            }
        }
    }

}
