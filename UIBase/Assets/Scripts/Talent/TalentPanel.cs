using UnityEngine;
using System.Collections;

public class TalentPanel : MonoBehaviour
{
    public TalentSlotList talentSlotList;
    private void OnValidate()
    {
        if (talentSlotList == null) talentSlotList = FindObjectOfType<TalentSlotList>();
    }
    public void Awake()
    {
        talentSlotList.OnRightClickEvent += ShowToolTip;
    }
    public void ShowToolTip(Talent talent)
    {

    }

    public void Upgrade()
    {
        talentSlotList.AddLevelRandom();
    }
}
