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
        bool playerWalking;

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
                    gameUISource.PlayOneShot(buttonClick); break;
                case AudioType.PLAYER_MOVE:
                    if (playerWalking)
                        return;
                    playerWalking = true;
                    playerSource.loop = true;
                    playerSource.clip = playerWalk;
                    playerSource.Play(); break;
            }
        }

        public void Stop(AudioType audioType)
        {
            switch (audioType)
            {
                case AudioType.PLAYER_MOVE:
                    if (!playerWalking)
                        return;
                    playerWalking = false;
                    playerSource.Stop(); break;
            }
        }
    }

    [System.Serializable]
    public class SoundData
    {
        public AudioType audioType;
        public AudioClip audioClip;
    }
}