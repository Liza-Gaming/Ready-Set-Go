using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * I learned from this video: https://www.youtube.com/watch?v=POq1i8FyRyQ&ab_channel=RehopeGames
 */
public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] float remainingTime;

    public static Timer Instance { get; private set; }

    void Awake()
    {
        // Implementing singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        if (remainingTime <= 0)
        {
            GameOverScreen();
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameOverScreen()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // I will make game over screen.
    }
}
