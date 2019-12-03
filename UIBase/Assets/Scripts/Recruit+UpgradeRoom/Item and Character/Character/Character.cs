using UnityEngine;
using System.Collections;
[System.Serializable]
public class Character
{
    public int id;
    public int type;
    public string characterName;
    public int level;
    public Character(int type, int id, string characterName, int level)
    {
        this.type = type;
        this.id = id;
        this.level = level;
        this.characterName = characterName;
    }
}
