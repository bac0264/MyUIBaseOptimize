using UnityEngine;
using System.Collections;

public class CharacterPanel : MonoBehaviour
{
    public CharacterStatManager CharacterStatManager;
    public CharacterInfomationUI characterUI;
    public CharacterSlotList characterSlotList;
    public SkeletonCharacter skeleton;
    private void OnValidate()
    {
        if (CharacterStatManager == null) CharacterStatManager = FindObjectOfType<CharacterStatManager>();
        if (characterUI == null) characterUI = GetComponentInChildren<CharacterInfomationUI>();
        if (characterSlotList == null) characterSlotList = GetComponentInChildren<CharacterSlotList>();
        if (skeleton == null) skeleton = GetComponentInChildren<SkeletonCharacter>();
    }
    public void Awake()
    {
        characterSlotList.OnRightClickEvent += ShowStat;
    }
    private void OnEnable()
    {
        skeleton.RefreshUI();
    }

    public void ShowStat(Character character)
    {
        characterUI.UpdateHeroUI(character);
    }
    public void Upgrade()
    {
        CharacterSlot characterSlot = characterSlotList.getCurrentSlot();
        if (characterSlot != null)
        {
            if (CharacterInfomationUI.instance != null)
            {
                if (characterSlot.CHARACTER.AddLevel(1))
                {
                    CharacterInfomationUI.instance.UpdateHeroUI(characterSlot.CHARACTER);
                    characterSlotList.SetupData();
                    ICharacterManager ICharacter = DIContainer.GetModule<ICharacterManager>();
                    ICharacter.SaveCharacterIntoPlayerPrefX();
                }
                else
                {
                    if (PopupFactory.instance != null) PopupFactory.instance.ShowPopup(BasePopup.TypeOfPopup.PO_Character);
                }
            }
        }
    }
}
