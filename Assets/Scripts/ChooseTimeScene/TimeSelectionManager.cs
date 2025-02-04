using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.CloudSave;
using System.Collections.Generic;

public class TimeSelectionManager : MonoBehaviour
{
    public async void SetTimeAndStartGame(float timeInMinutes)
    {
        TimerSettings.ChosenTimeInSeconds = timeInMinutes * 60; // Convert minutes to seconds
        TimerSettings.TimeHasBeenSet = true;

        // Save chosen time to cloud
        var data = new Dictionary<string, object>{
            {"ChosenTime", (int)timeInMinutes}
        };
        await CloudSaveService.Instance.Data.ForceSaveAsync(data);

        // Load game scene
        SceneManager.LoadScene("SampleScene");
    }
}
