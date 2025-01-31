using UnityEngine;
using UnityEngine.UI;

public class WinSceneController : MonoBehaviour
{
    [SerializeField] private Text winText;

    void Start()
    {
        // Get elapsed time
        float elapsedTime = Timer.Instance.GetElapsedTime();
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        string completionTime = $"{minutes:00}:{seconds:00}";

        // Get chosen time (from PlayerPrefs OR TimerSettings)
        int chosenTime = PlayerPrefs.GetInt("ChosenTime", Mathf.FloorToInt(TimerSettings.ChosenTimeInSeconds / 60));

        // Display result
        winText.text = $"{completionTime}";

        // Save the session
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
