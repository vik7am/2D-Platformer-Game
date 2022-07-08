using UnityEngine;
using UnityEngine.UI;

public class LobbyUIManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    void StartGame()
    {
        Utils.LoadLevel(1);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
