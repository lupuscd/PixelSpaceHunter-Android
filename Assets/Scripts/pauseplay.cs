using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseplay : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] Button resumeButton;

    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseButton.interactable = false;
        resumeButton.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseButton.interactable = true;
        resumeButton.gameObject.SetActive(false);
    }
}
