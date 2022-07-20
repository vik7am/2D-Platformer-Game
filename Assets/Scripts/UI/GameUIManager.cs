using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platatformer2D
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] GameObject levelCompletedPanel;
        [SerializeField] HealthUIController healthUI;
        [SerializeField] Text scoreText;
        [SerializeField] Text currentLevel;

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

        public void updateHealth(int remainingHeart)
        {
            healthUI.updateHeartUI(remainingHeart);
        }

        public void updateScoreUI()
        {
            scoreText.text = "Score : " + ScoreManager.GetScore();
        }
    }
}

