using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text currentScoreText;
    public Text bestScoreText;
   public int bestScore;
    public static int currentScore;
    public static int starCount;
    public Text scoreText;
    public Text[] starText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScoreText.text = currentScore.ToString();
        
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
            bestScoreText.text = bestScore.ToString();
        }
        else
        {
            bestScoreText.text = currentScore.ToString();
        }
        if (PlayerPrefs.HasKey("StarNumbers"))
        {
            foreach (Text t in starText)
            {
                starCount = PlayerPrefs.GetInt("StarNumbers");
                t.text = starCount.ToString();
            }
        }
        else
        {
            foreach (Text t in starText)
            {
                starCount = PlayerPrefs.GetInt("StarNumbers");
                t.text = starCount.ToString();
            }
        }
        scoreText.text = currentScore.ToString();
    }


    public void ResetScore()
    {
        currentScore = 0;
        currentScoreText.text = currentScore.ToString();
        scoreText.text = currentScore.ToString();
    }
    public void ScoreUpdate()
    {
        currentScore += 1;
        scoreText.text = currentScore.ToString();
        currentScoreText.text = currentScore.ToString();
        if (bestScore < currentScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            bestScoreText.text = currentScore.ToString();
        }
    }

    public void StarUpdate()
    {
        PlayerPrefs.SetInt("StarNumbers", starCount);
        foreach (Text t in starText)
        {
            t.text = starCount.ToString();
        }
    }
}
