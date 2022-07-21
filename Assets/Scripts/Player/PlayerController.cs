using System.Collections;
using UnityEngine;

namespace Platatformer2D
{
    public class PlayerController : MonoBehaviour
    {
        Animator animator;
        BoxCollider2D boxCollider2D;
        Rigidbody2D playerRigidBody;
        Vector3 scale;
        Vector3 position;
        bool isAlive;
        float horizontal;
        bool isGrounded;
        int availableHearts;
        [SerializeField] GameUIManager gameUIManager;
        [SerializeField] int hearts;
        [SerializeField] float speed;
        [SerializeField] float jumpForce;

        Vector2 idleOffset = new Vector2(0f, 1f);
        Vector2 idleSize = new Vector2(0.6f, 2.1f);
        Vector2 crouchOffset = new Vector2(-0.1f, 0.6f);
        Vector2 crouchSize = new Vector2(1f, 1.3f);

        private void Awake()
        {
            animator = GetComponent<Animator>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            playerRigidBody = GetComponent<Rigidbody2D>();
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
                return;
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
            {
                animator.SetBool("Crouch", true);
                boxCollider2D.offset = crouchOffset;
                boxCollider2D.size = crouchSize;
            }

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                animator.SetBool("Crouch", false);
                boxCollider2D.offset = idleOffset;
                boxCollider2D.size = idleSize;
            }
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
            animator.SetBool("Death", true);
            StartCoroutine(PlayDeathAnimation());
        }

        IEnumerator PlayDeathAnimation()
        {
            animator.SetBool("Death", true);
            yield return new WaitForSeconds(1);
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
            if (gameTag.compareTag(EnumTag.GROUND))
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
            if (gameTag.compareTag(EnumTag.GROUND))
                isGrounded = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            CustomTag gameTag = collision.gameObject.GetComponent<CustomTag>();
            if (gameTag == null)
                return;
            if (gameTag.compareTag(EnumTag.LEVEL_EXIT))
            {
                LevelManager.Instance.LevelCompleted();
                gameUIManager.showLevelCompletedPanel();
            }
            else if (gameTag.compareTag(EnumTag.PIT))
            {
                KillPlayer();
            }
        }
    }
}

