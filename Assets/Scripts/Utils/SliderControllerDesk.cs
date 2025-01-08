using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderController : SliderBar
{
    [SerializeField] public Text textToShow;

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
