using UnityEngine;

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
    public ScoreController scoreController;
    public HealthUIController healthUI;
    public int hearts;
    public float speed;
    public float jumpForce;
    
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
        if (Input.GetKeyDown(KeyCode.R))
            Utils.RestartCurrentLevel();
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
        if (Input.GetKeyDown(KeyCode.Space))
            if (isGrounded)
            {
                playerRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                animator.SetBool("Jump", true);
            }
    }

    public void playDeathAnimation()
    {
        animator.SetBool("Jump", false);
        animator.SetBool("Death", true);
    }

    public void PickUpKey(int score)
    {
        scoreController.IncreseScore(score);
    }

    public void takeDamage(int damage)
    {
        if (isAlive == false)
            return;
        availableHearts -= damage;
        if(availableHearts > 0)
        {
            healthUI.RemoveHeart(availableHearts);
            animator.SetTrigger("Hurt");
        }
        else
        {
            healthUI.RemoveHeart(0);
            scoreController.GameOver();
            isAlive = false;
            animator.SetBool("Death", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        animator.SetBool("Jump", false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() != null)
            return;
        isGrounded = false;
    }
}
