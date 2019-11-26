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
            for (int i = 0; i < 18; i++)
            {
                int levelUpgrade = Random.Range(0, 4);
                int type = Random.Range(0, 5);
                int id = 0;

                Item item = new Item(0, id, type, 1, 1, levelUpgrade, false);
                itemManager.AddItem(item);
            }
            for (int i = 0; i < 20; i++)
            {
                int type = 4;
                int id = Random.Range(0,2);

                Item item = new Item(0, id, type, 10, 1, 0, false);
                itemManager.AddItem(item);
            }

        }
    }
    public void NextScene()
    {
        SceneManager.LoadScene("Test");
    }
}
