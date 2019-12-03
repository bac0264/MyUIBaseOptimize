using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CharacterSlot : MonoBehaviour, IPointerClickHandler
{
    private Character character;
    
    public Image icon;
    public Image backGround;
    public Text level;

    public Action<Character> OnRightClickEvent;
    public Character CHARACTER
    {
        set
        {
            character = value;
            if (character == null) HideUI();
            else
            {
                if (icon != null) {
                    //icon.sprite = GetComponent sprite from db
                }
                if (backGround != null)
                {
                    //backGround.sprite = GetComponent sprite from db
                }
                if (level != null)
                {
                    level.text = (character.level + 1).ToString();
                }
            }
        }
        get
        {
            return character;
        }
    }
    public void HideUI()
    {
        if (icon != null)
            icon.gameObject.SetActive(false);
        if (level != null)
            level.gameObject.SetActive(false);
        if (backGround != null)
            backGround.gameObject.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && (eventData.button == PointerEventData.InputButton.Right || eventData.clickCount > 0))
        {
            if (OnRightClickEvent != null && character != null)
            {
                OnRightClickEvent(character);
            }
        }

    }
}
