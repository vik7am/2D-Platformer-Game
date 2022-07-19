using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] int score = 10;
    [SerializeField] float fadeOutTime = 1f;
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
