using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;
    public ItemSlotList itemSlotList;
    public EquipmentPanel equipMentSlotList;
    public ForgingUpgradePanel forgingUpgradePanel;
    public TalentPanel talentPanel;
    public CharacterPanel characterPanel;


    public Image[] image_Recruits;
    public Image[] image_Upgrade;
    public Sprite[] sprite_Recruits;
    public Sprite[] sprite_Upgrade;

    public Sprite Picking;
    public Sprite NoPicking;

    public GameObject recruitBtnContainer;
    public GameObject upgradeBtnContainer;
    private Image backGround;
    int id_recruit;
    int id_upgrade;
    private void Awake()
    {
        backGround = GetComponent<Image>();
        id_recruit = 0;
        id_upgrade = 0;
        if (instance == null) instance = this;
        if(PlayerPrefs.GetInt(KeySave.ROOM_1_AND_2) == 1)
        {
            _Equipment_Recruit();
            recruitBtnContainer.SetActive(true);
            upgradeBtnContainer.SetActive(false);
        }
        else
        {
            _Equipment_Upgrade();
            recruitBtnContainer.SetActive(false);
            upgradeBtnContainer.SetActive(true);
        }
    }
    private void OnValidate()
    {
        if (itemSlotList == null) itemSlotList = FindObjectOfType<ItemSlotList>();
        if (talentPanel == null) talentPanel = FindObjectOfType<TalentPanel>();
        if (equipMentSlotList == null) equipMentSlotList = FindObjectOfType<EquipmentPanel>();
        if (forgingUpgradePanel == null) forgingUpgradePanel = FindObjectOfType<ForgingUpgradePanel>();
    }
    public void _Equipment_Recruit()
    {
        id_recruit = 0;
        UpdateUI_Recruit(id_recruit);
        talentPanel.gameObject.SetActive(false);
        characterPanel.gameObject.SetActive(false);
        itemSlotList.gameObject.SetActive(true);
        equipMentSlotList.gameObject.SetActive(true);
    }
    public void _Talent_Recruit()
    {
        id_recruit = 1;
        UpdateUI_Recruit(id_recruit);
        equipMentSlotList.gameObject.SetActive(false);
        itemSlotList.gameObject.SetActive(false);
        characterPanel.gameObject.SetActive(false);
        talentPanel.gameObject.SetActive(true);
    }
    public void _Character_Recruit()
    {
        id_recruit = 2;
        UpdateUI_Recruit(id_recruit);
        talentPanel.gameObject.SetActive(false);
        equipMentSlotList.gameObject.SetActive(false);
        itemSlotList.gameObject.SetActive(false);
        characterPanel.gameObject.SetActive(true);
    }
    public void _ForgingUgrade_Upgrade()
    {
        id_upgrade = 1;
        UpdateUI_Upgrade(id_upgrade);
        equipMentSlotList.gameObject.SetActive(false);
        itemSlotList.gameObject.SetActive(true);
        forgingUpgradePanel.gameObject.SetActive(true);
    }
    public void _Equipment_Upgrade()
    {
        id_upgrade = 0;
        UpdateUI_Upgrade(id_upgrade);
        forgingUpgradePanel.gameObject.SetActive(false);
        itemSlotList.gameObject.SetActive(true);
        equipMentSlotList.gameObject.SetActive(true);
    }
    public void UpdateUI_Recruit(int id)
    {
        int i = 0;
        foreach(Image image in image_Recruits)
        {
            if( id == i)
            {
                image.sprite = Picking;
            }
            else
            {
                image.sprite = NoPicking;
            }
            image.SetNativeSize();
            i++;
        }
        backGround.sprite = sprite_Recruits[id];
    }
    public void UpdateUI_Upgrade(int id)
    {
        int i = 0;
        foreach (Image image in image_Upgrade)
        {
            if (id == i)
            {
                image.sprite = Picking;
            }
            else
            {
                image.sprite = NoPicking;
            }
            image.SetNativeSize();
            i++;
        }
        backGround.sprite = sprite_Upgrade[id];
    }
}
