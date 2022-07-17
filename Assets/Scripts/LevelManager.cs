using UnityEngine;

public class LevelManager : MonoBehaviour
{
    static LevelManager instance;

    public static LevelManager Instance { get { return instance; } }
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetLevelStatus(Level.LOBBY, LevelStatus.COMPLETED);
        SetLevelStatus(Level.LEVEL1, LevelStatus.UNLOCKED);
    }

    public LevelStatus GetLevelStatus(Level level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt("Level" + level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(Level level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt("Level" + level, (int)levelStatus);
    }

    public void LevelCompleted()
    {
        int currentLevel = Utils.getCurrentLevel();
        SetLevelStatus((Level)currentLevel, LevelStatus.COMPLETED);
        SetLevelStatus((Level)(++currentLevel), LevelStatus.UNLOCKED);
        Utils.LoadNextLevel();
    }

    [ContextMenu("Reset Game Data")]
    public void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Game Reset Sucessful");
    }
}
