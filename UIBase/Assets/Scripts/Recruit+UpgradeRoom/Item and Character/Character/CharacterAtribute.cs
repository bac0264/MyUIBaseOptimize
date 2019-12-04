using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterAtribute : MonoBehaviour
{
    public int id;
    public GameObject isActive;
    public GameObject isNotActive;
    public Text ActivableLevel;
    public Text DescribeValue;

    public void Active(string describe)
    {
       // DescribeValue.text = describe;
        isActive.SetActive(true);
        isNotActive.SetActive(false);
    }
    public void Unactive(string describe, string display)
    {
        ActivableLevel.text = display;
       // DescribeValue.text = describe;
        isActive.SetActive(false);
        isNotActive.SetActive(true);
    }

    public void UpdateAtribute(string describe, int level)
    {
        int temp = (level + 1) / KeySave.ATRIBUTE_HERO_UPGRADE;
        if (temp >= (id + 1))
        {
            Active(describe);
        }
        else
        {
            int _display = (id + 1) * KeySave.ATRIBUTE_HERO_UPGRADE;
            string display = _display.ToString();
            Unactive(describe, display);
        }
    }
}
