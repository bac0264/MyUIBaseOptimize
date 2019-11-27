using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class TalentSlot : MonoBehaviour, IPointerClickHandler
{
    private Talent talent;

    public Image BackGround;
    public Image Icon;

    public Text Level;

    public Action<Talent> OnRightClickEvent;
    public Talent TALENT
    {
        set
        {
            talent = value;
            TalentDatabase talentDB = TalentDatabase.instance;
            if (talentDB != null)
            {
                if (BackGround != null)
                {
                    BackGround.color = talentDB.GetBackground(TALENT.level);
                    BackGround.gameObject.SetActive(true);
                }
                if (Level != null)
                {
                    Level.text = (TALENT.level + 1).ToString();
                    Level.gameObject.SetActive(true);
                }
                if (Icon != null)
                {
                    Icon.sprite = talentDB.GetTalentSprite(TALENT.type.ToString());
                    if (Icon.sprite != null) Icon.gameObject.SetActive(true);
                    else Icon.gameObject.SetActive(false);
                }
            }
        }
        get
        {
            return talent;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && (eventData.button == PointerEventData.InputButton.Right || eventData.clickCount > 0))
        {
            if (OnRightClickEvent != null && talent != null)
            {
                OnRightClickEvent(talent);
            }
        }

    }
}
