using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface ITalentManager
{
    void SaveTalentIntoPlayerPrefX();
    Talent GetTalent(string type, string level);
    List<Talent> GetAllTalent();

    Dictionary<string, Talent> GetTalentDictionary();
}
