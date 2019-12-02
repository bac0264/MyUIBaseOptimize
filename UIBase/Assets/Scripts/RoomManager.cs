using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;
    public ItemSlotList itemSlotList;
    public EquipmentPanel equipMentSlotList;
    public ForgingUpgradePanel forgingUpgradePanel;
    public TalentPanel talentPanel;

    public Sprite[] listSprite;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void OnValidate()
    {
        if (itemSlotList == null) itemSlotList = FindObjectOfType<ItemSlotList>();
        if (talentPanel == null) talentPanel = FindObjectOfType<TalentPanel>();
        if (equipMentSlotList == null) equipMentSlotList = FindObjectOfType<EquipmentPanel>();
        if (forgingUpgradePanel == null) forgingUpgradePanel = FindObjectOfType<ForgingUpgradePanel>();
    }
    public void Equipment()
    {
        talentPanel.gameObject.SetActive(false);
        forgingUpgradePanel.gameObject.SetActive(false);
        itemSlotList.gameObject.SetActive(true);
        equipMentSlotList.gameObject.SetActive(true);
    }
    public void ForgingUgrade()
    {
        talentPanel.gameObject.SetActive(false);
        equipMentSlotList.gameObject.SetActive(false);
        itemSlotList.gameObject.SetActive(true);
        forgingUpgradePanel.gameObject.SetActive(true);
    }
    public void Talent()
    {
        equipMentSlotList.gameObject.SetActive(false);
        itemSlotList.gameObject.SetActive(false);
        forgingUpgradePanel.gameObject.SetActive(false);
        talentPanel.gameObject.SetActive(true);
    }
}
