using UnityEngine;
using UnityEngine.UI;


public class PlayerLives : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;
    public GameObject gameOverText;
    public GameObject LivesCounter;
    private Rigidbody2D rb;

    private void Start()
    {
        currentLives = maxLives;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            DecreaseLives();
        }
    }

    public void DecreaseLives(int amount = 1)
    {
        currentLives -= amount;

        if (currentLives <= 0)
        {
            GameOver();
        }
        else
        {
            DestroyLife();
        }
    }

    private void DestroyLife()
    {
        if (currentLives <= maxLives && currentLives >= 0)
        {
            Transform life = LivesCounter.transform.GetChild(currentLives);
            if (life != null)
            {
                Destroy(life.gameObject);
            }
        }
    }

    public void IncreaseLives(int amount = 1)
    {
        currentLives += amount;
        currentLives = Mathf.Min(currentLives, maxLives);
    }

    private void GameOver()
    {
        Destroy(gameObject);
    }
}
