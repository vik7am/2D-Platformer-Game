using UnityEngine;
using UnityEngine.UI;

namespace Platatformer2D
{
    public class ScoreController : MonoBehaviour
    {
        Text scoreText;
        int totalScore;

        private void Awake()
        {
            scoreText = GetComponent<Text>();
        }
        void Start()
        {
            totalScore = 0;
        }

        public void IncreseScore(int score)
        {
            totalScore += score;
            UpdateUI();
        }

        private void UpdateUI()
        {
            scoreText.text = "Score : " + totalScore;
        }
    }
}

