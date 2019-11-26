using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IResourceManager
{
    /// <summary>
    /// Reduce resource need.
    /// Tru mot luong tai nguyen theo gia tri truyen vao
    /// </summary>
    /// <param name="type"> loai cua tai nguyen</param>
    /// <param name="Value"> gia tri tai nguyen truyen vao </param>
    /// <returns></returns>
    bool ReduceResourceNeed(string type, float Value);
    /// <summary>
    /// Add resource need.
    /// Them mot luong tai nguyen theo gia tri truyen vao
    /// </summary>
    /// <param name="type"> loai cua tai nguyen</param>
    /// <param name="Value"> gia tri tai nguyen truyen vao </param>
    /// <returns></returns>
    bool AddResourceNeed(string type, float Value);
    /// <summary>
    /// Get resource need.
    /// Lay tai nguyen can thiet.
    /// </summary>
    /// <param name="type"> loai cua tai nguyen </param>
    /// <returns></returns>
    ResourceStat getResourceNeed(string type);
}
