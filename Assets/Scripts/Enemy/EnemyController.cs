using UnityEngine;

namespace Platatformer2D
{
    public class EnemyController : MonoBehaviour
    {
        bool moveForward;
        int direction;
        Animator animator;
        AudioSource audioSource;
        float leftEdgePosition;
        float rightEdgePosition;
        [SerializeField] Transform leftEdge;
        [SerializeField] Transform rightEdge;
        [SerializeField] int speed = 2;
        [SerializeField] int damage = 1;
        [Header("Sounds")]
        [SerializeField] AudioClip walkingSound;

        Vector3 lookRight = new Vector3(1, 1, 1);
        Vector3 lookLeft = new Vector3(-1, 1, 1);

        private void Awake()
        {
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
            leftEdgePosition = leftEdge.position.x;
            rightEdgePosition = rightEdge.position.x;
        }

        void Start()
        {
            moveForward = true;
            direction = 1;
            audioSource.clip = walkingSound;
            audioSource.loop = true;
            audioSource.Play();
        }

        void Update()
        {
            CheckPatrollingPath();
            MoveEnemy();
        }

        void MoveEnemy()
        {
            Vector3 position = transform.position;
            position.x += speed * direction * Time.deltaTime;
            transform.position = position;
        }

        void CheckPatrollingPath()
        {
            if (moveForward)
            {
                if (transform.position.x >= rightEdgePosition)
                {
                    moveForward = false;
                    direction = -1;
                    transform.localScale = lookLeft;
                }
            }
            else
            {
                if (transform.position.x <= leftEdgePosition)
                {
                    moveForward = true;
                    direction = 1;
                    transform.localScale = lookRight;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                float playerX = player.transform.position.x;
                float enemyX = transform.position.x;
                if ((moveForward && enemyX > playerX) || (!moveForward && enemyX < playerX))
                    return;
                animator.SetTrigger("Attack");
                SoundManager.Instance.Play(AudioType.ENEMY_ATTACK);
                player.takeDamage(damage);
            }
        }
    }
}
