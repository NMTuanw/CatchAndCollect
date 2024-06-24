using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject firstStar;
    [SerializeField] private GameObject secondStar;
    [SerializeField] private GameObject thirdStar;

    void Update()
    {
        UpdateScoreText();
        UpdateStarFromScoreUI();
    }

    private void UpdateScoreText()
    {
        scoreText.text = ScoreManager.instance.score.ToString();
    }

    private void UpdateStarFromScoreUI()
    {
        if (ScoreManager.instance.score >= ScoreManager.instance.firstStarScore)
        {
            ShowStar(firstStar);
        }
        if (ScoreManager.instance.score >= ScoreManager.instance.secondStarScore)
        {
            ShowStar(secondStar);
        }
        if (ScoreManager.instance.score >= ScoreManager.instance.thirdStarScore)
        {
            ShowStar(thirdStar);
        }
    }

    private void ShowStar(GameObject gameObject)
    {
        gameObject.SetActive(true);
        // add Effect
    }

}
