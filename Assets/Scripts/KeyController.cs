using UnityEngine;

public class KeyController : MonoBehaviour
{
    public int score = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.PickUpKey(score);
            Destroy(gameObject);
        }
    }
}
