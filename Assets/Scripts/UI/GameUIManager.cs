using UnityEngine;
using UnityEngine.UI;

namespace Platatformer2D
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] GameObject levelCompletedPanel;
        [SerializeField] Text scoreText;
        [SerializeField] Text currentLevel;
        [SerializeField] Image healthbar;
        [SerializeField] float totalHealth;

        private void Start()
        {
            UpdateUI();
        }

        void UpdateUI()
        {
            updateScoreUI();
            currentLevel.text = "Level " + Utils.getCurrentLevel();
        }

        public void showGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }

        public void showLevelCompletedPanel()
        {
            levelCompletedPanel.SetActive(true);
        }

        public void updateHealth(int currentHealth)
        {
            healthbar.fillAmount = currentHealth / totalHealth;
        }

        public void updateScoreUI()
        {
            scoreText.text = "Score : " + ScoreManager.GetScore();
        }
    }
}

