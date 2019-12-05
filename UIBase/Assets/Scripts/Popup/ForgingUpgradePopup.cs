using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ForgingUpgradePopup : BasePopup
{
    public static ForgingUpgradePopup instance;
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
