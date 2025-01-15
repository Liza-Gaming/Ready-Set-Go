using UnityEngine;
using UnityEngine.UI;

public class TaskInstructions : MonoBehaviour
{
    public GameObject instructionUI; // Assign the instruction UI
    public GameObject gameUI; // Assign the main game UI that should be hidden initially
    public GameObject gameTimer; // Reference to your Timer script

    void Start()
    {
        // Show instructions and hide the game UI initially
        instructionUI.SetActive(true);
        gameUI.SetActive(false);
        gameTimer.SetActive(false); // Disable timer initially
    }

    // Call this method when the button in the instruction UI is clicked
    public void StartGame()
    {
        instructionUI.SetActive(false);
        gameUI.SetActive(true);
        gameTimer.SetActive(true); // Enable the timer as the game starts
    }
}
