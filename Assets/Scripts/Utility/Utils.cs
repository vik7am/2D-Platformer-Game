using UnityEngine.SceneManagement;

namespace Platatformer2D
{
    public class Utils
    {
        public static void LoadLevel(int level)
        {
            ScoreManager.ResetScore();
            SceneManager.LoadScene(level);
        }

        public static void LoadNextLevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            int totalScene = SceneManager.sceneCountInBuildSettings;
            int nextScene = ++currentScene % totalScene;
            SceneManager.LoadScene(nextScene);
        }

        public static void RestartCurrentLevel()
        {
            ScoreManager.ResetScore();
            SceneManager.LoadScene(getCurrentLevel());
        }

        public static int getCurrentLevel()
        {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }
}

