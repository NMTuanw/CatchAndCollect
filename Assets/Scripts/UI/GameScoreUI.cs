using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Image scoreBarFillImage;

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
        int score = ScoreManager.instance.score;
        scoreText.text = score.ToString();

        // Update score bar fill
        UpdateScoreBar(score);
    }

    private void UpdateScoreBar(int score)
    {
        float maxScore = ScoreManager.instance.thirdStarScore;
        float fillAmount = (float)score / maxScore;
        scoreBarFillImage.fillAmount = Mathf.Clamp(fillAmount, 0f, 1f); 
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
