using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : ICharacterManager
{
    private readonly Dictionary<string, Character> characterList = new Dictionary<string, Character>();

    public CharacterManager()
    {
        if (PlayerPrefs.GetInt(KeySave.IS_GAME_FOR_THE_FIST, 0) == 0)
        {
            LoadForTheFirst();
        }
        else
            LoadAllCharacter();
    }
    private void LoadForTheFirst()
    {
        characterList.Clear();
        List<string> data = new List<string>();
        Character character = new Character(0, 0, "Bac Dzai", 0);
        string json = JsonUtility.ToJson(character);
        characterList.Add(character.id.ToString(),character);
        data.Add(json);
        PlayerPrefsX.SetStringArray(KeySave.HERO_LIST, data.ToArray());
    }
    private void LoadAllCharacter()
    {
        characterList.Clear();
        string[] data = PlayerPrefsX.GetStringArray(KeySave.HERO_LIST);
        foreach (string json in data)
        {
            try
            {
                Character character = JsonUtility.FromJson<Character>(json);
                characterList.Add(character.id.ToString(), character);
            }
            catch
            {

            }
        }
    }
    public void SaveCharacterIntoPlayerPrefX()
    {
        List<string> data = new List<string>();

        foreach (KeyValuePair<string, Character> ele1 in characterList)
        {
            string json = JsonUtility.ToJson(ele1.Value);
            data.Add(json);
        }
        PlayerPrefsX.SetStringArray(KeySave.HERO_LIST, data.ToArray());
    }
    public Character GetCharacter(int id)
    {
        if (characterList.ContainsKey(id.ToString()))
            return characterList[id.ToString()];
        return null;
    }
    public List<Character> GetAllCharacter()
    {
        List<Character> _talentList = new List<Character>();
        foreach (KeyValuePair<string, Character> ele1 in characterList)
        {
            _talentList.Add(ele1.Value);
            //Debug.Log("type: " + (TypeOfTalent.Type)ele1.Value.type+" , Level: "+ele1.Value.level);
        }
        return _talentList;
    }
    public Dictionary<string, Character> GetCharacterDictionary()
    {
        return characterList;
    }
    public void AddCharacter(Character character)
    {
        characterList.Add(character.id.ToString(), character);
        SaveCharacterIntoPlayerPrefX();
    }
}
