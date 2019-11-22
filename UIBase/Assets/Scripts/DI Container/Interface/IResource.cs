using UnityEngine;
using System.Collections;

public interface IResource
{
     bool ReduceResourceNeed(string type, float Value);
     bool AddResourceNeed(string type, float Value);
     ResourceStat getResourceNeed(string type);
     void SetupResourceForTheFirst();
     void SaveAllResource();
     void SaveResource(string str);
     void LoadAllResource();
}
