using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] Button[] levelButtons;
    int levelPassed;
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i >= levelPassed)
            {
                levelButtons[i].interactable = false;
            }
            else
            {
                levelButtons[i].interactable = true;
            }
        }
    }

    public void LevelToLoad(int levelNumber)
    {
        level.LoadFromButton(levelNumber);
    }
}
