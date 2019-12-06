using UnityEngine;
using System.Collections;

public class DailySpriteDatabase : MonoBehaviour
{
    public static DailySpriteDatabase instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public Sprite[] backgrounds;
    public Sprite[] picks;
    public Sprite[] icons;
    public Sprite getBackground(string type)
    {
        if (type.Equals(TypeOfResource.Type.GEM.ToString())){
            return backgrounds[1];
        }
        else
        {
            return backgrounds[0];
        }
    }
    public Sprite getPick(string type)
    {
        if (type.Equals(TypeOfResource.Type.GEM.ToString())){
            return picks[1];
        }
        else
        {
            return picks[0];
        }
    }
}
