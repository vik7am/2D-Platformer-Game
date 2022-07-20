using UnityEngine;
using UnityEngine.UI;

namespace Platatformer2D
{
    public class LobbyUIManager : MonoBehaviour
    {
        [SerializeField] Button continueButton;
        [SerializeField] Button selectLevel;
        [SerializeField] Button exitButton;
        [SerializeField] GameObject levelPanel;

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
}

