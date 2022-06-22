using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] Animator transition;
    float timePassed;

    public void LoadStartMenu()
    {
        StartCoroutine(LoadLevelCor("StartMenu", 1f));
    }
    public void LoadStartMenuAfterGameOver()
    {
        FindObjectOfType<LevelSession>().ResetGame();
        StartCoroutine(LoadLevelCor("StartMenu", 1f));
    }
    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadLevelCorNumb(nextSceneIndex, 1f));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadGameOver()
    {
        StartCoroutine(LoadGameOverCor("GameOver", 1f));
    }
    public void LoadHelpScreen()
    {
        StartCoroutine(LoadLevelCor("Help", 1f));
    }
    public void LoadOption()
    {
        StartCoroutine(LoadLevelCor("Option", 1f));
    }
    public string GetLevelNumber()
    {
        return SceneManager.GetActiveScene().name.ToString();
    }
    public void LoadLevelChoice()
    {
        StartCoroutine(LoadLevelCor("LevelChoice", 1f));
    }
    public void LoadFromButton(int levelNumber)
    {
        StartCoroutine(LoadLevelCorNumb(levelNumber, 1f));
    }
    public void LoadVictoryScene()
    {
        StartCoroutine(LoadLevelCor("Victory", 1f));
    }
    public void LoadFirstLevel()
    {
        FindObjectOfType<LevelSession>().ResetGame();
        StartCoroutine(LoadFirstLevel(1, 1f));
    }

    IEnumerator LoadFirstLevel(int levelNumber, float timePassed)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(timePassed);
        SceneManager.LoadScene(levelNumber);
    }

    IEnumerator LoadLevelCorNumb(int levelNumber, float timePassed)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(timePassed);
        SceneManager.LoadScene(levelNumber);
    }

    IEnumerator LoadLevelCor(string levelName, float timePassed)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(timePassed);
        SceneManager.LoadScene(levelName);
    }

    IEnumerator LoadGameOverCor(string levelName, float timePassed)
    {
        yield return new WaitForSeconds(2f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(timePassed);
        admobscript.instance.ShowInterstitialAD();
        SceneManager.LoadScene(levelName);
    }
}
