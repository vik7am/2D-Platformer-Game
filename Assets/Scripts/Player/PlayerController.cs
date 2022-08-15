using System.Collections;
using UnityEngine;

namespace Platatformer2D
{
    public class PlayerController : MonoBehaviour
    {
        Animator animator;
        Rigidbody2D playerRigidBody;
        AudioSource audioSource;
        Vector3 scale;
        Vector3 position;
        bool isAlive;
        float horizontal;
        bool isGrounded;
        int availableHearts;
        bool isWalking;
        [SerializeField] GameUIManager gameUIManager;
        [SerializeField] int hearts;
        [SerializeField] float speed;
        [SerializeField] float jumpForce;
        [Header("Sounds")]
        [SerializeField]AudioClip walkingSound;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            playerRigidBody = GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            isAlive = true;
            isGrounded = false;
            availableHearts = hearts;
        }

        void Update()
        {
            if (isAlive == false)
                return;
            MovePlayer();
            CrouchPlayer();
            JumpPlayer();
        }

        void MovePlayer()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            // Changing player postion if input is not equal to zero
            if (horizontal == 0)
            {
                if (isWalking)
                {
                    isWalking = false;
                    audioSource.Stop();
                }
                return;
            }
            else
            {
                if (!isWalking)
                {
                    isWalking = true;
                    audioSource.loop = true;
                    audioSource.clip = walkingSound;
                    audioSource.Play();
                }
            }
                
            position = transform.position;
            position.x += horizontal * speed * Time.deltaTime;
            transform.position = position;
            // Flipping player based on horizontal input
            scale = transform.localScale;
            scale.x = (horizontal < 0) ? -1 * Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        void CrouchPlayer()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
                animator.SetBool("Crouch", true);
            if (Input.GetKeyUp(KeyCode.LeftControl))
                animator.SetBool("Crouch", false);
        }

        void JumpPlayer()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                playerRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                animator.SetBool("Jump", true);
            }
        }

        public void PickUpKey(int score)
        {
            ScoreManager.IncreseScore();
            gameUIManager.updateScoreUI();
            SoundManager.Instance.Play(AudioType.KEY_COLLECTED);
        }

        public void takeDamage(int damage)
        {
            if (isAlive == false)
                return;
            availableHearts -= damage;
            if (availableHearts > 0)
            {
                gameUIManager.updateHealth(availableHearts);
                animator.SetTrigger("Hurt");
            }
            else
            {
                gameUIManager.updateHealth(0);
                KillPlayer();
            }
        }

        public void KillPlayer()
        {
            isAlive = false;
            animator.SetBool("Jump", false);
            horizontal = 0;
            animator.SetBool("Death", true);
            audioSource.Stop();
            SoundManager.Instance.Play(AudioType.LEVEL_FAIL);
        }

        public void showGameOverScreen()
        {
            gameUIManager.showGameOverPanel();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.GetComponent<EnemyController>() != null)
            {
                animator.SetBool("Jump", false);
            }
            CustomTag gameTag = collision.gameObject.GetComponent<CustomTag>();
            if (gameTag == null)
                return;
            if (gameTag.getTag() == EnumTag.GROUND || gameTag.getTag() == EnumTag.PLATFORM)
            {
                isGrounded = true;
                animator.SetBool("Jump", false);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            CustomTag gameTag = collision.gameObject.GetComponent<CustomTag>();
            if (gameTag == null)
                return;
            if (gameTag.getTag() == EnumTag.GROUND)
                isGrounded = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            CustomTag gameTag = collision.gameObject.GetComponent<CustomTag>();
            if (gameTag == null)
                return;
            if (gameTag.getTag() == EnumTag.LEVEL_EXIT)
            {
                //isAlive = false;
                audioSource.Stop();
                //animator.SetFloat("Speed", Mathf.Abs(0));
                LevelManager.Instance.LevelCompleted();
                SoundManager.Instance.Play(AudioType.LEVEL_COMPLETE);
                collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                StartCoroutine(LevelCompleted());
            }
            else if (gameTag.getTag() == EnumTag.PIT)
            {
                KillPlayer();
            }
        }

        IEnumerator LevelCompleted()
        {
            yield return new WaitForSeconds(2);
            gameUIManager.showLevelCompletedPanel();
        }
    }
}

