using UnityEngine;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;

    void Awake()
    {
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void showGameOverScreen()
    {
        gameObject.SetActive(true);
    }

    void RestartGame()
    {
        Utils.RestartCurrentLevel();
    }

    void QuitGame()
    {
        Utils.LoadLevel(0);
    }
}
