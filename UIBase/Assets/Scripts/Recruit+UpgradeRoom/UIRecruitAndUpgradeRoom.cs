using UnityEngine;
using System.Collections;

public class UIRecruitAndUpgradeRoom : UIBase
{
    public static UIRecruitAndUpgradeRoom instance;
    public RecruitAndUpgradeButton room;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void OnValidate()
    {
        type = TypeOfUI.UI_RecruitAndUpgradeRoom;
        if (room == null) room = FindObjectOfType<RecruitAndUpgradeButton>();
    }
    public override void HideUI()
    {
        base.HideUI();
    }
    public override void ShowUI()
    {
        room.Setup();
        base.ShowUI();
    }
}
