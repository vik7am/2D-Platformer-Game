using UnityEngine;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button quitButton;

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
        PlayerPrefs.SetInt("CURRENT_LEVEL", Utils.getCurrentLevel());
        Utils.LoadLevel(0);
    }
}
