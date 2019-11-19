using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAbtractFactory : MonoBehaviour
{
    public static UIAbtractFactory instance;

    public Dictionary<string, UIBaseFunction> baseFunctionList = new Dictionary<string, UIBaseFunction>();
}
