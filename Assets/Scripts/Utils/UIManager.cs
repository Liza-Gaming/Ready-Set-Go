using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text taskDisplay; // Reference to the UI Text that displays the tasks
    [SerializeField] private List<GameObject> arrowUI = new List<GameObject>(); // List of arrow GameObjects to toggle

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateTaskDisplay(int current, int total)
    {
        if (taskDisplay != null)
            taskDisplay.text = $"{current}/{total}"; // Update the UI text to show progress
    }

    // Method to control the visibility of arrows based on scene conditions
    public void ToggleArrows(bool showArrows)
    {
        foreach (var arrow in arrowUI)
        {
            if (arrow != null) arrow.SetActive(showArrows);
        }
    }
}