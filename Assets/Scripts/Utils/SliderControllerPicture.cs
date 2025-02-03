using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderControllerPicture : SliderBar
{
    [SerializeField] public Text textToShow;
    public DisplayImage displayImage; // Reference to the DisplayImage component
    public SelectItems selectItems; // Reference to the SelectItems component
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
        yield return new WaitForSeconds(1);
        textToShow.text = "";
        ResetTimer();
        selectItems.ResetObjects(); // Reset unactivated objects
        displayImage.StartDisplay(); // Display the image again
    }
}
