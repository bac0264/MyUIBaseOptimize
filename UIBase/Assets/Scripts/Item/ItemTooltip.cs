using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public Text FireRate;
    public Text Dame;
    public Text SpeedATK;
    private Item item;
    public void ShowItemTooltip(Item item)
    {
        this.item = item;
        FireRate.text = " coming soon ";
        Dame.text = " coming soon ";
        SpeedATK.text = " coming soon ";
    }
    public void HideItemTooltip()
    {
        gameObject.SetActive(false);
    }

    public void Equip()
    {

    }
    public void Unequip()
    {
        HideItemTooltip();
    }
}
