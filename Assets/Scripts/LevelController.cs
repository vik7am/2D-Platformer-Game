using UnityEngine;

public class LevelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Utils.LoadNextLevel();
    }
}
