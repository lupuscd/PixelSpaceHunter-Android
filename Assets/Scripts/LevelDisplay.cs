using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    TextMeshProUGUI levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        levelNumber = GetComponent<TextMeshProUGUI>();
        levelNumber.text = FindObjectOfType<Level>().GetLevelNumber();
    }
}
