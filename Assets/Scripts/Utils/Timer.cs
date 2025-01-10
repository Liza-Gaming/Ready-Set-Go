using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * I learned from this video: https://www.youtube.com/watch?v=POq1i8FyRyQ&ab_channel=RehopeGames
 */
public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private Image background;
    [SerializeField] private float remainingTime;
    private bool timerIsActive = false; // Control the timer's active state

    public static Timer Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe when destroyed
    }

    void Update()
    {
        if (timerIsActive && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 1)
        {
            SceneManager.LoadScene("GameOver");
        }

        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene")
        {
            timerIsActive = true; // Activate timer
            timerText.gameObject.SetActive(true); // Show timer UI
            background.gameObject.SetActive(true);
        }
        else
        {
            timerIsActive = false; // Deactivate timer
            timerText.gameObject.SetActive(false); // Hide timer UI
            background.gameObject.SetActive(false);
        }
    }
}
