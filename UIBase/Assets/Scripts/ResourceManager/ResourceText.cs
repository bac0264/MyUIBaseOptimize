using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ResourceText : MonoBehaviour
{
    private Text text;
    public void UpdateText()
    {
        IResourceManager itemManager = DIContainer.GetModule<IResourceManager>();
        ResourceStat resource = itemManager.getResourceNeed(name);
        if (resource != null)
            text.text = resource.value.ToString();
    }

}
