using UnityEngine;

public class KeyController : MonoBehaviour
{
    public int score = 10;
    public float moveUpSpeed = 1.5f;
    public float fadeOutTime = 1f;
    bool isCollected = false;
    //SpriteRenderer sprite;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        //sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isCollected)
        {
            MoveUp();
            //Fade();
        }
    }

    void MoveUp()
    {
        Vector3 position = transform.position;
        position.y += moveUpSpeed * Time.deltaTime;
        transform.position = position;
    }

    /*void Fade()
    {
        Color color = sprite.color;
        float alpha = sprite.color.a;
        alpha -= (1 / fadeOutTime) * Time.deltaTime;
        alpha = Mathf.Clamp(alpha, 0, 1);
        color.a = alpha;
        sprite.color = color;
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.PickUpKey(score);
            animator.SetBool("collected", true);
            isCollected = true;
            Destroy(gameObject, fadeOutTime);
        }
    }
}
