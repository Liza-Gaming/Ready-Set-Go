using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeSelectionManager : MonoBehaviour
{
    public void SetTimeAndStartGame(float timeInMinutes)
    {
        TimerSettings.ChosenTimeInSeconds = timeInMinutes * 60; // Convert minutes to seconds
        TimerSettings.TimeHasBeenSet = true;

        // Save chosen time for future reference
        PlayerPrefs.SetInt("ChosenTime", (int)timeInMinutes);
        PlayerPrefs.Save();

        // Load game scene
        SceneManager.LoadScene("SampleScene");
    }
}
