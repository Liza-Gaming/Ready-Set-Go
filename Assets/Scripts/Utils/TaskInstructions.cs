using UnityEngine;
using UnityEngine.UI;

public class TaskInstructions : MonoBehaviour
{
    public GameObject instructionUI;
    public GameObject gameUI;
    public GameObject gameTimer;

    void Start()
    {
        // Show instructions and hide the game UI initially
        instructionUI.SetActive(true);
        gameUI.SetActive(false);
        gameTimer.SetActive(false);
    }

    // Call this method when the button in the instruction UI is clicked
    public void StartGame()
    {
        instructionUI.SetActive(false);
        gameUI.SetActive(true);
        gameTimer.SetActive(true); // Enable the timer as the game starts
    }
}
