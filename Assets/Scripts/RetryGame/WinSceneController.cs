using UnityEngine;
using UnityEngine.UI;
using Unity.Services.CloudSave;
using System.Collections.Generic;
using Unity.Services.Authentication;  // For playerId

public class WinSceneController : MonoBehaviour
{
    [SerializeField] private Text winText;

    async void Start()
    {
        // Fetch chosen time (Optional if you still need it separately.)
        var keysToLoad = new HashSet<string> { "ChosenTime" };
        var loadedData = await CloudSaveService.Instance.Data.LoadAsync(keysToLoad);
        int chosenTime = 0;
        if (loadedData.TryGetValue("ChosenTime", out var loadedChosenTimeValue)
            && int.TryParse(loadedChosenTimeValue.ToString(), out chosenTime))
        {
            Debug.Log("Successfully retrieved chosen time: " + chosenTime);
        }
        else
        {
            Debug.LogError("Failed to retrieve or parse chosen time");
        }

        // Calculate elapsed time
        float elapsedTime = Timer.Instance.GetElapsedTime();
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        string completionTime = $"{minutes:00}:{seconds:00}";

        // Display result
        winText.text = completionTime;

        // -------------------------------
        // Instead of ForceSaveAsync(...) to "ChosenTime" and "FinishedTime",
        // call CloudSave.Instance.SaveSession(...) so that you keep
        // appending sessions in the "PlayerSessions" list
        // -------------------------------
        CloudSave.Instance.SaveSession(
            AuthenticationService.Instance.PlayerId,  // or some unique player ID
            chosenTime,
            completionTime
        );
    }
}
