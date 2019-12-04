using UnityEngine;
using System.Collections;
[System.Serializable]
public class Character
{
    public int id;
    public int type;
    public string characterName;
    public int level;
    public bool isPick;
    public Character(int type, int id, string characterName, int level, bool isPick)
    {
        this.type = type;
        this.id = id;
        this.level = level;
        this.characterName = characterName;
        this.isPick = isPick;
    }
    public bool AddLevel(int level)
    {
        if (level > 0 && this.level < KeySave.MAX_LEVEL_HERO)
        {
            this.level += level;
            return true;
        }
        return false;
    }
}
