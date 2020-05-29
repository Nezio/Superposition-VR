using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgressSaver : MonoBehaviour
{
    private void Start()
    {
        // save last played level
        string level = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("lastLevelPlayed", level);

        // save overall level progress
        int levelNumber = Tools.GetLevelNumber(level);
        int maxLevelPlayed = PlayerPrefs.GetInt("maxLevelPlayed", 0);
        if(levelNumber > maxLevelPlayed)
        {
            PlayerPrefs.SetInt("maxLevelPlayed", levelNumber);
        }
    }

}
