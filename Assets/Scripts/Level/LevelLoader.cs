using UnityEngine;
using UnityEngine.UI;

namespace Platatformer2D
{
    public class LevelLoader : MonoBehaviour
    {
        Button button;
        [SerializeField] Level level;

        void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(LoadSelectedLevel);
        }

        void Start()
        {
            if (LevelManager.Instance.GetLevelStatus(level) == LevelStatus.LOCKED)
                button.interactable = false;
        }

        void LoadSelectedLevel()
        {
            LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(level);
            SoundManager.Instance.Play(AudioType.START_LEVEL);
            Utils.LoadLevel((int)level);
        }
    }
}

