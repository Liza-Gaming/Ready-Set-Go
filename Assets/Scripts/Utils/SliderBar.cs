using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField]
    [Tooltip("A UI Slider used to visually represent the countdown time")]
    public Slider timerslider;

    [SerializeField]
    [Tooltip("Flag to indicate whether the timer should stop")]
    protected bool stopTimer;

    // Flag to indicate if the timer is running
    public bool isTimerRunning;

    [SerializeField]
    [Tooltip("The maximum time the slider will represent (initial timer value)")]
    public float maxTime;

    // Variable to track the number of consecutive failures
    private int failureCount = 0;

    // Variable to adjust the speed of the timer based on failures
    private float timerSpeedAdjustment = 1.0f;

    protected virtual void Start()
    {
        ResetTimer(); // Initialize and reset timer
        StartCountdown(); // Begin countdown immediately
    }

    protected virtual void Update()
    {
        if (!isTimerRunning)
            return;

        float time = timerslider.value - (Time.deltaTime * timerSpeedAdjustment);

        if (time <= 0)
        {
            stopTimer = true;
            isTimerRunning = false;
            ResetTimer();
        }

        if (!stopTimer)
        {
            timerslider.value = time;
        }
    }

    public void IncreaseFailureCount(int n)
    {
        failureCount++;
        if (failureCount >= n)
        {
            timerSpeedAdjustment = 0.5f;
        }
    }

    protected void StartCountdown()
    {
        isTimerRunning = true;
    }

    protected virtual void ResetTimer()
    {
        stopTimer = false;
        timerslider.value = maxTime;
        StartCountdown();
    }
}
