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
    public void UpdateCharacterStat(EquipmentPanel characterStat)
    {
        hpStat.text = characterStat.character.HP.Value.ToString();
        dameStat.text = characterStat.character.Dame.Value.ToString();
        powerStat.text = characterStat.character.Power.Value.ToString();
    }
}
