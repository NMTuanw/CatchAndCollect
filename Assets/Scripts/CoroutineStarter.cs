using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineStarter : MonoBehaviour
{
    private static CoroutineStarter _instance;

    public static CoroutineStarter Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("CoroutineStarter");
                _instance = obj.AddComponent<CoroutineStarter>();
                DontDestroyOnLoad(obj); // Optional: to persist across scenes
            }
            return _instance;
        }
    }
}
