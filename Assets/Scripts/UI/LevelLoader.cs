using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    enum Level {LEVEL1 = 1, LEVEL2 = 2, LEVEL3 = 3, LEVEL4 = 4};
    Button button;
    [SerializeField] Level level;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadSelectedLevel);
    }

    void LoadSelectedLevel()
    {
        Utils.LoadLevel((int)level);
    }
}
