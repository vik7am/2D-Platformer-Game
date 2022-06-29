using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    BoxCollider2D boxCollider2D;
    Rigidbody2D playerRigidBody;
    Vector3 scale;
    Vector3 position;
    float horizontal;
    bool isGrounded = false;
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

    void Update()
    {
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
                playerRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        animator.SetBool("Jump", false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        animator.SetBool("Jump", true);
    }
}
