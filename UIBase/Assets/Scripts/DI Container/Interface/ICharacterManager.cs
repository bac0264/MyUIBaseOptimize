﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface ICharacterManager
{
    void SaveCharacterIntoPlayerPrefX();
    Character GetCharacter(int id);
    Character GetCurrentCharacter();
    List<Character> GetAllCharacter();
    Dictionary<string, Character> GetCharacterDictionary();
    void AddCharacter(Character character);
}
