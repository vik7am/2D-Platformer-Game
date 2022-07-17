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

    public LevelStatus GetLevelStatus(Level level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt("Level" + level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(Level level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt("Level" + level, (int)levelStatus);
    }
}
