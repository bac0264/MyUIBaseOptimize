using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class ResourceManager : IResource
{
    public static ResourceManager instance;
    public Dictionary<string, ResourceStat> resourceList;
    public ResourceManager()
    {
        Debug.Log("run");
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
    //private void Awake()
    //{
    //    if (instance == null) instance = this;
    //    if (!PlayerPrefs.HasKey("IsTheFirst"))
    //    {
    //        PlayerPrefs.SetInt("IsTheFirst", 0);
    //        SetupResourceForTheFirst();
    //    }
    //    else
    //    {
    //        LoadAllResource();
    //    }
    //    DebugResource();
    //}
    // Save Load
    //private void OnDisable()
    //{
    //    SaveAllResource();
    //}
    public void SetupResourceForTheFirst()
    {
        resourceList = new Dictionary<string, ResourceStat>();
        foreach (string str in Enum.GetNames(typeof(TypeOfResource.Type)))
        {
            TypeOfResource type = new TypeOfResource
            {
                type = TypeOfResource.ConvertStringToEnum(str)
            };
            ResourceStat resource = new ResourceStat(PlayerPrefs.GetFloat(str, 0), type);
            Debug.Log(type);
            resourceList.Add(str, resource);
        }
    }
    public void SaveAllResource()
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
    public void SaveResource(string str)
    {
        ResourceStat resource = getResourceNeed(str);
        if (resource != null)
            PlayerPrefs.SetFloat(str, getResourceNeed(str).value);
        else
        {
            PlayerPrefs.SetFloat(str, 0);
        }
    }
    public void LoadAllResource()
    {
        resourceList = new Dictionary<string, ResourceStat>();
        foreach (string str in Enum.GetNames(typeof(TypeOfResource.Type)))
        {
            TypeOfResource type = new TypeOfResource
            {
                type = TypeOfResource.ConvertStringToEnum(str)
            };
            Debug.Log(type);
            ResourceStat resource = new ResourceStat(PlayerPrefs.GetFloat(str, 0), type);
            resourceList.Add(str, resource);
        }
    }
    public void DebugResource()
    {
        foreach (KeyValuePair<string, ResourceStat> ele1 in resourceList)
        {
            Debug.Log("Key: "+ele1.Key+ " ,Resource:  "+ele1.Value.Type.type.ToString()+ " ,value: "+ele1.Value.value);
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
        try
        {
            return resourceList[type];
        }
        catch
        {
            return null;
        }
    }
}
