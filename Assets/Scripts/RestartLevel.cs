using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    public GameOverUIController gameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerController>().playDeathAnimation();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameOver.showGameOverScreen();
    }
}
