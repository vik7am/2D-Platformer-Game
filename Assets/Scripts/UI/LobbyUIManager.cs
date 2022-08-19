using UnityEngine;
using UnityEngine.UI;

namespace Platatformer2D
{
    public class LobbyUIManager : MonoBehaviour
    {
        [SerializeField] GameObject levelPanel;
        [SerializeField] Button selectLevelButton;
        [SerializeField] Button startGameButton;
        Text startGameButtonText;

        void Awake()
        {
            selectLevelButton.onClick.AddListener(ToggleLevelUI);
            startGameButtonText = startGameButton.GetComponentInChildren<Text>();
        }

        private void Start()
        {
            if (LevelManager.Instance.GetLevelStatus(Level.LOBBY) == LevelStatus.LOCKED)
            {
                LevelManager.Instance.UnlockFirstLevel();
                startGameButtonText.text = "NEW GAME";
            }
            else
            {
                startGameButtonText.text = "CONTINUE";
            }
        }

        void ToggleLevelUI()
        {
            levelPanel.SetActive(!levelPanel.activeInHierarchy);
            SoundManager.Instance.Play(AudioType.BUTTON_CLICK);
        }
    }
}

