using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderController : SliderBar
{
    [SerializeField] public Text textToShow;
    [SerializeField] private int failureCount = 1;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (timerslider.value <= 0 && !stopTimer)
        {
            stopTimer = true;
            textToShow.text = "Too late, Resetting time";
            IncreaseFailureCount(failureCount);
            StartCoroutine(ShowFeedbackAndReset());
        }
    }

    private IEnumerator ShowFeedbackAndReset()
    {
        yield return new WaitForSeconds(2);
        textToShow.text = "";
        ResetTimer();
    }
}
