using UnityEngine;
using UnityEngine.UI;

public class LobbyUIManager : MonoBehaviour
{
    public Button continueButton;
    public Button selectLevel;
    public Button exitButton;
    public GameObject levelPanel;

    void Awake()
    {
        continueButton.onClick.AddListener(ContinueGame);
        selectLevel.onClick.AddListener(SelectLevel);
        exitButton.onClick.AddListener(ExitGame);
    }

    void ContinueGame()
    {
        int currentLevel = PlayerPrefs.GetInt("CURRENT_LEVEL", 1);
        Utils.LoadLevel(currentLevel);
    }

    void SelectLevel()
    {
        levelPanel.SetActive(true);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
