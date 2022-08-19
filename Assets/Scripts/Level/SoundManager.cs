using UnityEngine;

namespace Platatformer2D
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;
        public AudioSource gameUISource;
        public AudioSource playerSource;
        public AudioClip buttonClick;
        public AudioClip playerWalk;
        public AudioClip startLevel;
        public AudioClip levelComplete;
        public AudioClip levelFail;
        public AudioClip keyCollected;
        public AudioClip enemyAttack;

        public static SoundManager Instance { get { return instance; } }

        private void Awake()
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

        public void Play(AudioType audioType)
        {
            switch (audioType)
            {
                case AudioType.BUTTON_CLICK: 
                    gameUISource.PlayOneShot(buttonClick, 0.25f);
                    break;
                case AudioType.START_LEVEL:
                    gameUISource.PlayOneShot(startLevel, 0.25f);
                    break;
                case AudioType.LEVEL_COMPLETE:
                    gameUISource.PlayOneShot(levelComplete);
                    break;
                case AudioType.LEVEL_FAIL:
                    gameUISource.PlayOneShot(levelFail, 0.5f);
                    break;
                case AudioType.KEY_COLLECTED:
                    gameUISource.PlayOneShot(keyCollected, 0.2f);
                    break;
                case AudioType.ENEMY_ATTACK:
                    playerSource.PlayOneShot(enemyAttack, 0.5f);
                    break;
            }
        }
    }
}