using UnityEngine;

namespace Platatformer2D
{
    public class EnemyController : MonoBehaviour
    {
        Vector3 startPosition;
        Vector3 endPosition;
        bool moveForward;
        int direction;
        [SerializeField] GameObject start;
        [SerializeField] GameObject end;
        [SerializeField] int speed = 2;
        [SerializeField] int damage = 1;
        Animator animator;
        AudioSource audioSource;
        [Header("Sounds")]
        [SerializeField] AudioClip walkingSound;

        Vector3 faceForward = new Vector3(1, 1, 1);
        Vector3 faceBackward = new Vector3(-1, 1, 1);

        private void Awake()
        {
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
            startPosition = start.transform.position;
            endPosition = end.transform.position;
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
                if (transform.position.x >= endPosition.x)
                {
                    moveForward = false;
                    direction = -1;
                    transform.localScale = faceBackward;
                }
            }
            else
            {
                if (transform.position.x <= startPosition.x)
                {
                    moveForward = true;
                    direction = 1;
                    transform.localScale = faceForward;
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
                player.takeDamage(damage);
            }
        }
    }
}
