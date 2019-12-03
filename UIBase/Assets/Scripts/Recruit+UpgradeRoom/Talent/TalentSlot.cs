using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class TalentSlot : MonoBehaviour, IPointerClickHandler
{
    private Talent talent;

    public Image BackGround;
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
                    BackGround.sprite = talentDB.GetBackground(TALENT.level);
                    BackGround.gameObject.SetActive(true);
                }
                if (Level != null)
                {
                    Level.text = (TALENT.level + 1).ToString();
                    Level.gameObject.SetActive(true);
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
