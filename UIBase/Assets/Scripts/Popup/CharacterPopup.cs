using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterPopup : BasePopup
{
    public static CharacterPopup instance;
    public Text comingSoon;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public override void HidePopup()
    {
        base.HidePopup();
    }

    public override void ShowPopup()
    {
        base.ShowPopup();
    }
}
