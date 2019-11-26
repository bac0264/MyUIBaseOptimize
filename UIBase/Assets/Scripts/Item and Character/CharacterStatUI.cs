using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterStatUI : MonoBehaviour
{
    public static CharacterStatUI instance;
    public Text hpStat;
    public Text dameStat;
    public Text powerStat;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void UpdateCharacterStat(CharacterAction characterStat)
    {
        hpStat.text = characterStat.HP.Value.ToString();
        dameStat.text = characterStat.Dame.Value.ToString();
        powerStat.text = characterStat.Power.Value.ToString();
    }
}
