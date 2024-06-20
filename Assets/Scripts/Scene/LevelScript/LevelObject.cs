using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelObject : MonoBehaviour
{
    public Button levelButton;
    public GameObject levelLockImage;
    public Image[] stars;

    void Update()
    {
        if (levelButton.interactable == true)
        {
            levelLockImage.SetActive(false);
        }
    }
}
