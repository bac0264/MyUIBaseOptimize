using UnityEngine;
using System.Collections;
using System;

public class CharacterSlotList : MonoBehaviour
{
    public CharacterSlot[] characterList;

    public Action<Character> OnRightClickEvent;
    private void Start()
    {
        foreach(CharacterSlot character in characterList)
        {
            character.OnRightClickEvent += OnRightClickEvent;
        }
    }
    private void OnValidate()
    {
        if (characterList.Length == 0) characterList = GetComponentsInChildren<CharacterSlot>();
    }
}
