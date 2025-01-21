using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderControllerPicture : SliderBar
{
    [SerializeField] public Text textToShow;
    public DisplayImage displayImage; // Reference to the DisplayImage component
    public SelectItems selectItems; // Reference to the SelectItems component

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
        selectItems.ResetObjects(); // Reset unactivated objects
        displayImage.StartDisplay(); // Display the image again
    }
}
