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
        DIContainer.SetModule<ICharacterManager, CharacterManager>();
        IItemManager itemManager = DIContainer.GetModule<IItemManager>();
        if (PlayerPrefs.GetInt("1", 0) == 0)
        {
            //PlayerPrefs.SetInt("1", 1);
            for (int i = 0; i < 15; i++)
            {
                int levelUpgrade = Random.Range(0, 2);
                int type = 0;
                int id = Random.Range((int)WeaponType.Type.knife, (int)WeaponType.Type.doublePisol + 1);
                Item item = new Item(0, id, type, 1, 0, levelUpgrade, false);
                itemManager.AddItem(item);
            }
            //for (int i = 0; i < 5; i++)
            //{
            //    int type = (int)TypeOfItem.Type.Other;
            //    int id = i;

            //    Item item = new Item(0, id, type, 100, 0, 0, false);
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
