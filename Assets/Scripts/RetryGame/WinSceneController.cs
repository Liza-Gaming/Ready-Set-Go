using UnityEngine;
using UnityEngine.UI;
using Unity.Services.CloudSave;
using System.Collections.Generic;
using Unity.Services.Authentication;

/**
 * Saves the score
 */
public class WinSceneController : MonoBehaviour
{
    [SerializeField] private Text winText;

    async void Start()
    {
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

        CloudSave.Instance.SaveSession(
            AuthenticationService.Instance.PlayerId,
            chosenTime,
            completionTime
        );
    }
}
