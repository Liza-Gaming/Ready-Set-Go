using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private Image background;
    [SerializeField] private float remainingTime;
    private bool timerIsActive = false; // Control the timer's active state
    private float initialTime; // To store the initial chosen time

    public static Timer Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
            if (TimerSettings.TimeHasBeenSet)
            {
                SetInitialTime(TimerSettings.ChosenTimeInSeconds);
                TimerSettings.TimeHasBeenSet = false; // Reset the flag
            }
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

    public void SetInitialTime(float newTime)
    {
        initialTime = newTime;
        remainingTime = newTime;
        timerIsActive = true;
        UpdateTimerUI();
    }

    void Update()
    {
        if (timerIsActive && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            // Ensure the timer never goes below 0
            if (remainingTime < 0)
            {
                remainingTime = 0;
            }

            UpdateTimerUI();
        }

        if (remainingTime == 0 && timerIsActive)
        {
            timerIsActive = false;
            SceneManager.LoadScene("GameOver");
        }
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void LoadWinScene()
    {
        timerIsActive = false; // Stop the timer
        SceneManager.LoadScene("WinScene"); // Load the Win scene
    }

    public float GetElapsedTime()
    {
        return initialTime - remainingTime; // Calculate elapsed time
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene")
        {
            timerIsActive = true; // Activate timer
            timerText.gameObject.SetActive(true); // Show timer UI
            background.gameObject.SetActive(true);
        }
        else if (scene.name == "GameOver")
        {
            timerIsActive = false; // Stop timer
            timerText.gameObject.SetActive(false); // Hide timer UI
            background.gameObject.SetActive(false);

            Destroy(gameObject);
        }
        else
        {
            timerIsActive = false; // Deactivate timer
            timerText.gameObject.SetActive(false); // Hide timer UI
            background.gameObject.SetActive(false);
        }
    }

    public void ResetTimer()
    {
        timerIsActive = false;
        UpdateTimerUI();
    }
}
