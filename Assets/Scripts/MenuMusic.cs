using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType<MenuMusic>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        var activeScene = SceneManager.GetActiveScene().name;
        if (activeScene != "Help" && activeScene != "StartMenu" && activeScene != "GameOver" && activeScene != "Option" && activeScene != "LevelChoice" &&
            activeScene != "Victory")
        {
            Destroy(gameObject);
        }
    }
}
