using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHideGameObject : MonoBehaviour
{
    public void ShowGameObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void HideGameObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
