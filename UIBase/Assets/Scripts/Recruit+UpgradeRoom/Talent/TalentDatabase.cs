using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TalentDatabase : MonoBehaviour
{
    public static TalentDatabase instance;
    public Sprite[] backGroundList;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public Sprite GetBackground(float levelUpgrade)
    {
        if (levelUpgrade < 4) return backGroundList[0];
        else if (levelUpgrade >= 4 && levelUpgrade < 8) return backGroundList[1];
        else if (levelUpgrade >= 8 && levelUpgrade < 12) return backGroundList[2];
        else return backGroundList[3];
    }

}
