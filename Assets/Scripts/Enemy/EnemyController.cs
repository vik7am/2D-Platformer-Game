using UnityEngine;

namespace Platatformer2D
{
    public class EnemyController : MonoBehaviour
    {
        Vector3 startPosition;
        Vector3 endPosition;
        bool moveForward;
        int direction;
        [SerializeField] int speed = 2;
        [SerializeField] int damage = 1;
        Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            startPosition = transform.GetChild(0).transform.position;
            endPosition = transform.GetChild(1).transform.position;
        }

        void Start()
        {
            moveForward = true;
            direction = 1;
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
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else
            {
                if (transform.position.x <= startPosition.x)
                {
                    moveForward = true;
                    direction = 1;
                    transform.localScale = new Vector3(1, 1, 1);
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


