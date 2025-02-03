using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StoveSliderBar : SliderBar
{
    [SerializeField] public Text textToShow;
    [SerializeField] public float loweLimit = 0.85f;
    [SerializeField] public float upperLimit = 1.6f;
    [SerializeField] private int failureCount = 3;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    protected override void Start()
    {
        base.Start();
        textToShow.text = "Press the button on time!";
    }

    protected override void Update()
    {
        base.Update();

        if (timerslider.value <= 0)
        {
            textToShow.text = "Too late";
            IncreaseFailureCount(failureCount);
            stopTimer = true;
            StartCoroutine(ShowFeedbackAndReset());
        }
    }

    // Public method to be called by UI button click
    public void OnButtonPress()
    {
        HandlePress();
    }

    private void HandlePress()
    {
        if (timerslider.value >= loweLimit && timerslider.value <= upperLimit)
        {
            textToShow.text = "On time!";
            audioManager.PlaySFX(audioManager.rightPress);
            stopTimer = true;
            SceneManager.LoadScene("SampleScene");
        }
        else if (timerslider.value < loweLimit)
        {
            textToShow.text = "Too late";
            IncreaseFailureCount(failureCount);
            audioManager.PlaySFX(audioManager.wrongPress);
            stopTimer = true;
            StartCoroutine(ShowFeedbackAndReset());
        }
        else if (timerslider.value > upperLimit)
        {
            textToShow.text = "Too early";
            IncreaseFailureCount(failureCount);
            audioManager.PlaySFX(audioManager.wrongPress);
            stopTimer = true;
            StartCoroutine(ShowFeedbackAndReset());
        }
        else
        {
            stopTimer = true;
            StartCoroutine(ShowFeedbackAndReset());
        }
    }

    private IEnumerator ShowFeedbackAndReset()
    {
        ResetTimer();
        yield return new WaitForSeconds(2);
        textToShow.text = "Press the button on time!";
    }
}
