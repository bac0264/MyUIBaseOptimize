using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemFilter : MonoBehaviour
{
    public Button[] btns;
    public Sprite Picking;
    public Sprite NoPicking;
    private void OnValidate()
    {
        if (btns.Length == 0) btns = GetComponentsInChildren<Button>();
    }
    private void Awake()
    {
        for (int i = 0; i < btns.Length; i++)
        {
            int z = i - 1;
            if(i == 0) SetBtn(z.ToString(), z + 1);
            btns[i].onClick.AddListener(delegate { SetBtn(z.ToString(), z+1); });
        }
    }
    public void SetBtn(string type, int index)
    {
        if (RecruitAndUpgradeButton.instance != null) RecruitAndUpgradeButton.instance.itemSlotList.Filter(type.ToString());
        for (int i = 0; i < btns.Length; i++)
        {
            Image image = btns[i].GetComponent<Image>();
            if (i == index)
            {
                image.sprite = Picking;
                image.SetNativeSize();
            }
            else
            {
                image.sprite = NoPicking;
                image.SetNativeSize();
            }
        }
    }
    public void All()
    {
        if (EquipmentPanel.instance != null) EquipmentPanel.instance.itemSlotList.Filter("-1");
    }
    public void Weapon()
    {
        if (EquipmentPanel.instance != null) EquipmentPanel.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Weapon).ToString());
    }
    public void Ring()
    {
        if (EquipmentPanel.instance != null) EquipmentPanel.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Ring).ToString());
    }
    public void Amulet()
    {
        if (EquipmentPanel.instance != null) EquipmentPanel.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Amulet).ToString());
    }
    public void Armor()
    {
        if (EquipmentPanel.instance != null) EquipmentPanel.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Armor).ToString());
    }
    public void Other()
    {
        if (EquipmentPanel.instance != null) EquipmentPanel.instance.itemSlotList.Filter(((float)TypeOfItem.Type.Other).ToString());
    }

}
