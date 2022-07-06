using UnityEngine;

public class KeyController : MonoBehaviour
{
    public int score = 10;
    public float fadeOutTime = 1f;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.PickUpKey(score);
            animator.SetBool("collected", true);
            Destroy(gameObject, fadeOutTime);
        }
    }
}
