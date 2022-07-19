using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletedController : MonoBehaviour
{
    public Button nextLevel;
    public Button quitButton;

    void Awake()
    {
        nextLevel.onClick.AddListener(StartNextLevel);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void showLevelCompletedScreen()
    {
        gameObject.SetActive(true);
    }

    public void StartNextLevel()
    {
        Utils.LoadNextLevel();
    }

    void QuitGame()
    {
        PlayerPrefs.SetInt("CURRENT_LEVEL", Utils.getCurrentLevel());
        Utils.LoadLevel(0);
    }
}
