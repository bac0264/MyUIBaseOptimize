using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterInfomationUI : CharacterStatUI
{
    public static CharacterInfomationUI instance;

    public Text Name;
    public Text LevelHero;
    public CharacterAtributeList atributeList;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    // Use this for initialization
    private void OnValidate()
    {
        if (atributeList == null) atributeList = GetComponentInChildren<CharacterAtributeList>();
    }
    public void UpdateHeroUI(Character character)
    {
        atributeList.UpdateHeroUI(character.level);
        Name.text = character.characterName;
        LevelHero.text = (character.level + 1).ToString();
        if (CharacterStatManager.instance != null)
        {
            CharacterStatManager.instance.SetupCurrentCharacter();
            UpdateCharacterStat(CharacterStatManager.instance);
        }
    }
}
