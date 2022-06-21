using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public GameObject idleCollider;
    public GameObject crouchCollider;
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
        /*if (speed < 0)
            scale.x = -1 * absScaleX;
        else if (speed > 0)
            scale.x = absScaleX;*/
        transform.localScale = scale;
    }

    void CrouchPlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            idleCollider.SetActive(false);
            crouchCollider.SetActive(true);
        }
            
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
            idleCollider.SetActive(true);
            crouchCollider.SetActive(false);
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
