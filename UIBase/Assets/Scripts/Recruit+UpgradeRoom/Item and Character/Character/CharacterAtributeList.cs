using UnityEngine;
using System.Collections;

public class CharacterAtributeList : MonoBehaviour
{
    public CharacterAtribute[] characterAtributeList;

    private void OnValidate()
    {
        if (characterAtributeList.Length == 0) characterAtributeList = GetComponentsInChildren<CharacterAtribute>();
    }
    private void Awake()
    {
        int i = 0;
        foreach (CharacterAtribute characterAtr in characterAtributeList)
        {
            characterAtr.id = i;
            i++;
        }
    }
    public void UpdateHeroUI(int level, string[] describes)
    {
        int i = 0;
        foreach (CharacterAtribute characterAtr in characterAtributeList)
        {
            characterAtr.UpdateAtribute(describes[i], level);
            i++;
        }
    }
    public void UpdateHeroUI(int level)
    {
        int i = 0;
        foreach (CharacterAtribute characterAtr in characterAtributeList)
        {
            characterAtr.UpdateAtribute("", level);
            i++;
        }
    }
}
