using UnityEngine;

public class GameOverController : MonoBehaviour
{
    void Start()
    {
        // Get the chosen time from PlayerPrefs or TimerSettings
        int chosenTime = PlayerPrefs.GetInt("ChosenTime", Mathf.FloorToInt(TimerSettings.ChosenTimeInSeconds / 60));

        // Since the player ran out of time, we set the finished time to "00:00"
        string completionTime = "00:00";

        // Save the session indicating the player ran out of time
        GameDataManager gameData = FindObjectOfType<GameDataManager>();
        if (gameData != null)
        {
            gameData.SaveSession(chosenTime, completionTime);
        }
        else
        {
            Debug.LogWarning("GameDataManager not found in scene!");
        }
    }
}
