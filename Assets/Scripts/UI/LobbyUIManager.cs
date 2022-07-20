using UnityEngine;
using UnityEngine.UI;

namespace Platatformer2D
{
    public class LobbyUIManager : MonoBehaviour
    {
        [SerializeField] GameObject levelPanel;
        [SerializeField] Button selectLevelButton;

        void Awake()
        {
            selectLevelButton.onClick.AddListener(ToggleLevelUI);
        }

        void ToggleLevelUI()
        {
            levelPanel.SetActive(!levelPanel.activeInHierarchy);
        }
    }
}

