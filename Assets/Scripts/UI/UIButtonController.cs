using UnityEngine;
using UnityEngine.UI;

namespace Platatformer2D
{
    public class UIButtonController : MonoBehaviour
    {
        Button button;
        [SerializeField] ButtonType buttonType;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            switch (buttonType)
            {
                case ButtonType.START : StartGame(); break;
                case ButtonType.EXIT: ExitGame();  break;
                case ButtonType.RESTART: break;
                case ButtonType.QUIT: break;
                case ButtonType.NEXT_LEVEL: break;
            }
        }

        void StartGame()
        {
            int currentLevel = PlayerPrefs.GetInt("CURRENT_LEVEL", 1);
            Utils.LoadLevel(currentLevel);
        }

        void ExitGame()
        {
            Application.Quit();
        }

        void RestartGame()
        {
            Utils.RestartCurrentLevel();
        }

        void QuitLevel()
        {
            PlayerPrefs.SetInt("CURRENT_LEVEL", Utils.getCurrentLevel());
            Utils.LoadLevel(0);
        }

        void NextLevel()
        {
            Utils.LoadNextLevel();
        }
    }
}

