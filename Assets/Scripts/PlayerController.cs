using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxCollider2D;
    public Rigidbody2D playerRigidBody;
    public float speed;
    public float jumpForce;
    Vector3 scale;
    Vector3 position;
    float horizontal;
    bool isGrounded = false;

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
            boxCollider2D.offset = new Vector2(-0.1047657f, 0.5840551f);
            boxCollider2D.size = new Vector2(0.7091421f, 1.307235f);
        }
            
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
            boxCollider2D.offset = new Vector2(-0.01120976f, 0.984367f);
            boxCollider2D.size = new Vector2(0.6556816f, 2.107859f);
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
