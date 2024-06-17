using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // Adjust the speed of scrolling
    private RectTransform rectTransform;
    private Vector2 originalPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, rectTransform.rect.width);
        rectTransform.anchoredPosition = originalPosition + new Vector2(-newPosition, 0);
    }
}
