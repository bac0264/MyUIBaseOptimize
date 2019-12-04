using UnityEngine;
using System.Collections;

public class CharacterPanel : MonoBehaviour
{
    public CharacterStatManager CharacterStatManager;
    public CharacterInfomationUI characterUI;
    public CharacterSlotList characterSlotList;
    private void OnValidate()
    {
        if (CharacterStatManager == null) CharacterStatManager = FindObjectOfType<CharacterStatManager>();
        if (characterUI == null) characterUI = GetComponentInChildren<CharacterInfomationUI>();
        if (characterSlotList == null) characterSlotList = GetComponentInChildren<CharacterSlotList>();
    }
    public void Awake()
    {
        characterSlotList.OnRightClickEvent += ShowStat;
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
            }
        }
    }
}
