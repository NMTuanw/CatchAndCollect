using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnloadScript : MonoBehaviour
{
    public string objectID;
    private void Awake()
    {
        objectID = name;
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroyOnloadScript>().Length; i++)
        {
            if (Object.FindObjectsOfType<DontDestroyOnloadScript>()[i].objectID == objectID &&
                Object.FindObjectsOfType<DontDestroyOnloadScript>()[i] != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}