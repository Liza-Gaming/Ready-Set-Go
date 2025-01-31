// Script to display history in the HistoryScene
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DisplayHistoryUI : MonoBehaviour
{
    [SerializeField] private Text historyText;

    private void Start()
    {
        DisplayHistory();
    }

    private void DisplayHistory()
    {
        GameDataManager gameDataManager = FindObjectOfType<GameDataManager>();
        if (gameDataManager == null)
        {
            historyText.text = "No data manager found or no sessions saved.";
            return;
        }

        var sessions = gameDataManager.LoadData();
        if (sessions == null || sessions.Count == 0)
        {
            historyText.text = "No session history.";
            return;
        }

        historyText.text = "Session History:\n";
        foreach (var session in sessions)
        {
            historyText.text += $"Chosen: {session.chosenTime} min, Finished in: {session.completionTime}\n";
        }
    }

    public void RefreshHistoryDisplay()
    {
        historyText.text = "";
    }
}
