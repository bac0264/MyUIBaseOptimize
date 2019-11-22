using UnityEngine;
using System.Collections;

public class InitDI : MonoBehaviour
{
    private void Awake()
    {

        DIContainer.SetModule<IResource, ResourceManager>();
    }
}
