using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeSelectionManager : MonoBehaviour
{
    public void SetTimeAndStartGame(float timeInMinutes)
    {
        TimerSettings.ChosenTimeInSeconds = timeInMinutes * 60; // Convert minutes to seconds
        TimerSettings.TimeHasBeenSet = true;
        SceneManager.LoadScene("SampleScene"); // Load the SampleScene where the Timer will be instantiated
    }
}
