using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelIfScore : MonoBehaviour
{
    [SerializeField] int pointsToNextLevel = 300;

    Level level;
    LevelSession levelSession;
    int currentScore;
    int levelPassed;
    int sceneIndex;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        levelSession = FindObjectOfType<LevelSession>();
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = levelSession.GetScore();
        if (currentScore >= pointsToNextLevel)
        {
            if (levelPassed < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelPassed", sceneIndex);
            }
            if (sceneIndex == 10)
            {
                level.LoadVictoryScene();
            }
            else
            {
                level.LoadNextLevel();
            }            
        }
    }

    public string ShowPoints()
    {
        return pointsToNextLevel.ToString();
    }
}
