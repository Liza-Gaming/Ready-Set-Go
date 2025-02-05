using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Services.CloudSave;
using System.Threading.Tasks;
/**
 * Shows the scores in the HistoryScene
 */
public class ScoreboardController : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform contentPanel;

    private async void Start()
    {
        await LoadAndDisplayScores();
    }

    private async Task LoadAndDisplayScores()
    {
        string key = "PlayerSessions";

        try
        {
            var loadedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { key });

            if (loadedData.TryGetValue(key, out var jsonData) && !string.IsNullOrEmpty(jsonData.ToString()))
            {
                SaveDataWrapper dataWrapper = JsonUtility.FromJson<SaveDataWrapper>(jsonData.ToString());

                DisplayScores(dataWrapper);
            }
            else
            {
                Debug.Log("No session history found.");
                CreateTextEntry("No scores available.");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error loading scores: " + e.Message);
            CreateTextEntry("Failed to load scores.");
        }
    }

    private void DisplayScores(SaveDataWrapper dataWrapper)
    {
        foreach (PlayerSession session in dataWrapper.sessions)
        {
            string scoreText = $"Chosen Time: {session.chosenTime} minutes\nFinished Time: {session.finishedTime}\n";
            CreateTextEntry(scoreText);
        }
    }

    private void CreateTextEntry(string text)
    {
        GameObject newText = Instantiate(textPrefab, contentPanel);
        newText.GetComponent<Text>().text = text;
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

[System.Serializable]
public class Session
{
    public string playerId;
    public int chosenTime;
    public string finishedTime;
}

[System.Serializable]
public class PlayerHistory
{
    public Session[] sessions;
}

