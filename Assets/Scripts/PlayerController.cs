using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxCollider2D;
    float speed;
    float absSpeed;
    Vector3 scale;
    float absScaleX;
    float vertical;

    void Update()
    {
        MovePlayer();
        CrouchPlayer();
        JumpPlayer();
    }

    void MovePlayer()
    {
        speed = Input.GetAxisRaw("Horizontal");
        absSpeed = Mathf.Abs(speed);
        animator.SetFloat("Speed", absSpeed);
        if (speed == 0)
            return;
        scale = transform.localScale;
        absScaleX = Mathf.Abs(scale.x);
        scale.x = (speed < 0) ? -1 * absScaleX : absScaleX;
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
        vertical = Input.GetAxisRaw("Vertical");
        if (vertical > 0)
            animator.SetBool("Jump", true);
        else
            animator.SetBool("Jump", false);
    }
}
