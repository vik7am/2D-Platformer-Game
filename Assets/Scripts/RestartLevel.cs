using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerController>().playDeathAnimation();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Utils.RestartCurrentLevel();
    }
}
