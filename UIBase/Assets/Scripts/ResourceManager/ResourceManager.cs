using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class ResourceManager : IResourceManager
{
    public Dictionary<string, ResourceStat> resourceList;
    public ResourceManager()
    {
        if (!PlayerPrefs.HasKey("IsTheFirst"))
        {
            PlayerPrefs.SetInt("IsTheFirst", 0);
            SetupResourceForTheFirst();
        }
        else
        {
            LoadAllResource();
        }
    }
    /// <summary>
    /// Setup for the first time login game.
    /// Thiet lap cho lan dau vao game
    /// </summary>
    private void SetupResourceForTheFirst()
    {
        resourceList = new Dictionary<string, ResourceStat>();
        foreach (string str in Enum.GetNames(typeof(TypeOfResource.Type)))
        {
            TypeOfResource type = new TypeOfResource
            {
                type = TypeOfResource.ConvertStringToEnum(str)
            };
            ResourceStat resource = new ResourceStat(PlayerPrefs.GetFloat(str, 0), type);
            resourceList.Add(str, resource);
        }
    }
    /// <summary>
    /// This function save all Resource.
    /// Chuc nang nay luu tat ca cac resource lai
    /// </summary>
    private void SaveAllResource()
    {
        foreach (string str in Enum.GetNames(typeof(TypeOfResource.Type)))
        {
            ResourceStat resource = getResourceNeed(str);
            if (resource != null)
                PlayerPrefs.SetFloat(str, getResourceNeed(str).value);
            else
            {
                PlayerPrefs.SetFloat(str, 0);
            }
        }
    }
    /// <summary>
    /// Save each element based on type of resource.
    /// Luu moi phan tu dua vao loai tai nguyen 
    /// </summary>
    private void SaveResource(string str)
    {
        ResourceStat resource = getResourceNeed(str);
        if (resource != null)
            PlayerPrefs.SetFloat(str, getResourceNeed(str).value);
        else
        {
            PlayerPrefs.SetFloat(str, 0);
        }
    }

    /// <summary>
    /// Load all resource to list dictionary.
    /// Luu toan bo tai nguyen vao list dictionary
    /// </summary>
    private void LoadAllResource()
    {
        resourceList = new Dictionary<string, ResourceStat>();
        foreach (string str in Enum.GetNames(typeof(TypeOfResource.Type)))
        {
            TypeOfResource type = new TypeOfResource
            {
                type = TypeOfResource.ConvertStringToEnum(str)
            };
            ResourceStat resource = new ResourceStat(PlayerPrefs.GetFloat(str, 0), type);
            resourceList.Add(str, resource);
        }
    }
    public void DebugResource()
    {
        foreach (KeyValuePair<string, ResourceStat> ele1 in resourceList)
        {
            Debug.Log("Key: " + ele1.Key + " ,Resource:  " + ele1.Value.Type.type.ToString() + " ,value: " + ele1.Value.value);
        }
    }

    public bool ReduceResourceNeed(string type, float Value)
    {
        ResourceStat resourceNeed = getResourceNeed(type);
        if (resourceNeed != null && Value > 0)
        {
            resourceNeed.ReduceValue(Value);
            SaveResource(type);
            return true;
        }
        return false;
    }


    public bool AddResourceNeed(string type, float Value)
    {
        ResourceStat resourceNeed = getResourceNeed(type);
        if (resourceNeed != null && Value > 0)
        {
            Debug.Log("Run");
            resourceNeed.AddValue(Value);
            SaveResource(type);
            return true;
        }
        return false;
    }
    public ResourceStat getResourceNeed(string type)
    {
        if (resourceList.ContainsKey(type))
            return resourceList[type];
        return null;
    }
}
