using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class InitDI : MonoBehaviour
{
    private void Awake()
    {
        DIContainer.SetModule<IResourceManager, ResourceManager>();
        DIContainer.SetModule<IItemManager, ItemManager>();
        DIContainer.SetModule<ITalentManager, TalentManager>();
        IItemManager itemManager = DIContainer.GetModule<IItemManager>();
        ITalentManager talentManger = DIContainer.GetModule<ITalentManager>();
        List<Talent> talents = talentManger.GetAllTalent();
        if (PlayerPrefs.GetInt("1", 0) == 0)
        {
            PlayerPrefs.SetInt("1", 1);
            for (int i = 0; i < 9; i++)
            {
                int levelUpgrade = 0;//Random.Range(0, 4);
                int type = 0;//Random.Range(0, 4);
                int id = 0;

                Item item = new Item(0, id, type, 1, 0, levelUpgrade, false);
                itemManager.AddItem(item);
            }
            //for (int i = 0; i < 20; i++)
            //{
            //    int type = (int)TypeOfItem.Type.Other;
            //    int id = Random.Range((int)OtherType.Type.RUBY_Weapon, (int)OtherType.Type.ENERGON);

            //    Item item = new Item(0, id, type, 10, 0, 0, false);
            //    itemManager.AddItem(item);
            //}
            itemManager.SaveItemIntoPlayerPrefX();
        }
    }
    private void Start()
    {
        if(PlayerPrefs.GetInt(KeySave.IS_GAME_FOR_THE_FIST, 0) == 0)
        {
            PlayerPrefs.SetInt(KeySave.IS_GAME_FOR_THE_FIST, 1);
        }
    }
    public void NextScene()
    {
        SceneManager.LoadScene("Test");
    }
}
