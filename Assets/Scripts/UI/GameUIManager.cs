using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platatformer2D
{
    public class GameUIManager : MonoBehaviour
    {
        GameObject gameOverPanel;
        GameObject levelCompletedPanel;

        void showGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }

        void showLevelCompletedPanel()
        {
            levelCompletedPanel.SetActive(true);
        }
    }
}

