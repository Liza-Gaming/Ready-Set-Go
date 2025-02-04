using UnityEngine;
using Unity.Services.CloudSave;
using System.Collections.Generic;
using Unity.Services.Authentication;  // for playerId

public class GameOverController : MonoBehaviour
{
    async void Start()
    {
        // (Optionally) fetch chosen time 
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

        // --------------------------------
        // Instead of ForceSaveAsync(...), append a new session:
        // --------------------------------
        CloudSave.Instance.SaveSession(
            AuthenticationService.Instance.PlayerId,
            chosenTime,
            "00:00" // or whatever you want to record for a "GameOver" scenario
        );
    }
}
