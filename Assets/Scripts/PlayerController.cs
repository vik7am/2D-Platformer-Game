using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    float speed;
    float absSpeed;
    Vector3 scale;
    float absScaleX;

    void Update()
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
}
