using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterStatUI : MonoBehaviour
{
    public Text hpStat;
    public Text dameStat;
    public Text powerStat;

    public virtual void UpdateCharacterStat(CharacterStatManager CharacterStatManager)
    {
        hpStat.text = CharacterStatManager.HP.Value.ToString();
        dameStat.text = CharacterStatManager.Dame.Value.ToString();
        powerStat.text = CharacterStatManager.Power.Value.ToString();
    }
}
