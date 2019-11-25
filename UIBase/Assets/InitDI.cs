using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InitDI : MonoBehaviour
{
    private void Awake()
    {
        DIContainer.SetModule<IResourceManager, ResourceManager>();
        DIContainer.SetModule<IItemManager, ItemManager>();
        IItemManager itemManager = DIContainer.GetModule<IItemManager>();
        if (PlayerPrefs.GetInt("1", 0) == 0)
        {
            PlayerPrefs.SetInt("1", 1);
            for (int i = 0; i < 10; i++)
            {
                int levelUpgrade = Random.Range(0, 3);
                int type = Random.Range(0,6);
                int id = Random.Range(0, 1);

                Item item = new Item(0, id, type, 1, 1, levelUpgrade, false);
                itemManager.AddItem(item);
            }
        }
    }
}
