using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CharacterSlotList : MonoBehaviour
{
    public CharacterSlot[] characterList;

    public Action<Character> OnRightClickEvent;
    private void Start()
    {
        SetupEvent();
    }
    private void OnEnable()
    {
        SetupData();
    }
    private void OnValidate()
    {
        if (characterList.Length == 0) characterList = GetComponentsInChildren<CharacterSlot>();
    }
    public CharacterSlot getCurrentSlot()
    {
        foreach(CharacterSlot character in characterList)
        {
            if (character.CHARACTER.isPick) return character;
        }
        return null;
    }
    public void SetupData()
    {
        ICharacterManager characterManager = DIContainer.GetModule<ICharacterManager>();
        if (characterManager == null) return;
        List<Character> list = characterManager.GetAllCharacter();
        int i = 0;
        for (; i < list.Count && i < characterList.Length; i++)
        {
            characterList[i].CHARACTER = list[i];
        }
        for (; i < characterList.Length; i++)
        {
            characterList[i].CHARACTER = null;
        }
    }
    public void SetupEvent()
    {
        foreach (CharacterSlot character in characterList)
        {
            character.OnRightClickEvent += OnRightClickEvent;
        }
    }
}
