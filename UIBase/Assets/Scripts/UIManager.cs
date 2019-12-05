using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void _CharacterRoom()
    {
        PlayerPrefs.SetInt(KeySave.RECRUIT_OR_FORGING, 0);
        if (UIAbtractFactory.instance != null) UIAbtractFactory.instance.ShowPopup(UIBase.TypeOfUI.UI_RecruitAndUpgradeRoom);
    }
    public void _ForgingUpgradeRoom()
    {
        PlayerPrefs.SetInt(KeySave.RECRUIT_OR_FORGING, 1);
        if (UIAbtractFactory.instance != null) UIAbtractFactory.instance.ShowPopup(UIBase.TypeOfUI.UI_RecruitAndUpgradeRoom);
    }
    public void _GamePlay()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
