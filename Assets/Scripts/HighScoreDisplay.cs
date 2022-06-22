using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI highScoreText;
    LevelSession levelSession;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();
        levelSession = FindObjectOfType<LevelSession>();
        highScoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        UpdateHishScore();
    }

    private void UpdateHishScore()
    {
        int currentScore = levelSession.GetScore();
        int highScore = PlayerPrefs.GetInt("Highscore", 0);

        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("Highscore", currentScore);
            highScoreText.text = currentScore.ToString();
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("Highscore");
    }
}
