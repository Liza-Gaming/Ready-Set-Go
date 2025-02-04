using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using System;

public class CloudSave : MonoBehaviour
{
    private const string CLOUD_SAVE_CHOSEN_TIME_KEY = "chosenTime";
    private const string CLOUD_SAVE_FINISHED_TIME_KEY = "finishedTime";

    public static CloudSave Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupAndSignIn();
    }

    // This part of the code should be done at the beginning of your game flow (i.e. Main Menu)
    async void SetupAndSignIn()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Example test save, remove or modify for actual game inputs

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadDataWithErrorHandling();
        }
    }

    public async void SaveSession(string playerId, int chosenTime, string finishedTime)
    {
        var key = "PlayerSessions";
        SaveDataWrapper dataWrapper;

        try
        {
            // Load existing sessions
            var loadedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { key });
            if (loadedData.TryGetValue(key, out var existingData) && !string.IsNullOrEmpty(existingData.ToString()))
            {
                dataWrapper = JsonUtility.FromJson<SaveDataWrapper>(existingData.ToString());
            }
            else
            {
                dataWrapper = new SaveDataWrapper();
            }

            // Add new session
            dataWrapper.sessions.Add(new PlayerSession(playerId, chosenTime, finishedTime));

            // Serialize and save updated data
            string json = JsonUtility.ToJson(dataWrapper);
            await CloudSaveService.Instance.Data.ForceSaveAsync(new Dictionary<string, object> { { key, json } });
            Debug.Log("Session saved: " + json);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to load or save session data: " + e.Message);
        }
    }


    async void LoadDataWithErrorHandling()
    {
        var keysToLoad = new HashSet<string> {
            CLOUD_SAVE_CHOSEN_TIME_KEY,
            CLOUD_SAVE_FINISHED_TIME_KEY
        };
        try
        {
            var loadedData = await CloudSaveService.Instance.Data.LoadAsync(keysToLoad);

            if (loadedData.TryGetValue(CLOUD_SAVE_CHOSEN_TIME_KEY, out var loadedChosenTime))
            {
                Debug.Log("Loaded saved chosen time: " + loadedChosenTime);
            }
            else
            {
                Debug.Log("Chosen time not found in cloud save");
            }

            if (loadedData.TryGetValue(CLOUD_SAVE_FINISHED_TIME_KEY, out var loadedFinishedTime))
            {
                Debug.Log("Loaded saved finished time: " + loadedFinishedTime);
            }
            else
            {
                Debug.Log("Finished time not found in cloud save");
            }
        }
        catch (ServicesInitializationException e)
        {
            // service not initialized
            Debug.LogError(e);
        }
        catch (CloudSaveValidationException e)
        {
            // validation error
            Debug.LogError(e);
        }
        catch (CloudSaveRateLimitedException e)
        {
            // rate limited
            Debug.LogError(e);
        }
        catch (CloudSaveException e)
        {
            Debug.LogError(e);
        }
    }

    [System.Serializable]
public class PlayerSession
{
    public string playerId;
    public int chosenTime;
    public string finishedTime;

    public PlayerSession(string playerId, int chosenTime, string finishedTime)
    {
        this.playerId = playerId;
        this.chosenTime = chosenTime;
        this.finishedTime = finishedTime;
    }
}

[System.Serializable]
public class SaveDataWrapper
{
    public List<PlayerSession> sessions = new List<PlayerSession>();
}
}


