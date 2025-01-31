using UnityEngine;
using System.Collections.Generic;

public class GameDataManager : MonoBehaviour
{
    private List<PlayerSession> playerSessions = new List<PlayerSession>();

    public static GameDataManager Instance;

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

    void Start()
    {
        LoadData(); // Load previous session data at start
    }

    public void SaveSession(int chosenTime, string completionTime)
    {
        PlayerSession newSession = new PlayerSession(chosenTime, completionTime);
        playerSessions.Add(newSession);

        // Convert to JSON and save in PlayerPrefs
        string json = JsonUtility.ToJson(new SaveDataWrapper { sessions = playerSessions });
        PlayerPrefs.SetString("PlayerSessions", json);
        PlayerPrefs.Save();

        Debug.Log("Game session saved: " + json);
    }

    public List<PlayerSession> LoadData()
    {
        if (PlayerPrefs.HasKey("PlayerSessions"))
        {
            string json = PlayerPrefs.GetString("PlayerSessions");
            SaveDataWrapper data = JsonUtility.FromJson<SaveDataWrapper>(json);

            if (data != null && data.sessions != null)
            {
                playerSessions = data.sessions;
            }
        }
        return playerSessions;
    }

    [System.Serializable]
    private class SaveDataWrapper
    {
        public List<PlayerSession> sessions;
    }
    public void ClearSessionHistory()
    {
        PlayerPrefs.DeleteKey("PlayerSessions"); // Clear the stored sessions
        PlayerPrefs.Save(); // Save the changes
    }

    public void ResetData()
    {
        Destroy(gameObject);
        Instance = null;
    }

}

[System.Serializable]
public class PlayerSession
{
    public int chosenTime;       // 5, 7, or 10 minutes
    public string completionTime; // Time in "MM:SS" format
    public string timestamp;     // Date/time of the session

    public PlayerSession(int chosenTime, string completionTime)
    {
        this.chosenTime = chosenTime;
        this.completionTime = completionTime;
        this.timestamp = System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
