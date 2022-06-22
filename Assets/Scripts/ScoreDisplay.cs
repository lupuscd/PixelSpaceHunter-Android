using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    LevelSession levelSession;
    NextLevelIfScore nextLevelScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        levelSession = FindObjectOfType<LevelSession>();
        nextLevelScore = FindObjectOfType<NextLevelIfScore>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = levelSession.GetScore().ToString() + "/" + nextLevelScore.ShowPoints();
    }
}
